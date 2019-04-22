(function () {
	"use strict";

	var marcados = 0;
	var verifyCheckeds = function ($checks) {
		if (marcados >= 2) {
			loop($checks, function ($element) {
				$element.disabled = $element.checked ? '' : 'disabled';
			});
		} else {
			loop($checks, function ($element) {
				$element.disabled = '';
			});
		}
	};
	var loop = function ($elements, cb) {
		var max = $elements.length;
		while (max--) {
			cb($elements[max]);
		}
	}
	var count = function ($element) {
		return $element.checked ? marcados + 1 : marcados - 1;
	}
	window.onload = function () {
		//var $checks = document.querySelectorAll('input[type="checkbox"]');
		var $checks = document.querySelectorAll('.acompanhamento');

		loop($checks, function ($element) {
			$element.onclick = function () {
				marcados = count(this);
				verifyCheckeds($checks);
			}
			if ($element.checked) marcados = marcados + 1;
		});
		verifyCheckeds($checks);
	}
}());


function GetCliente(url) {
	var queryString = url ? url.split('?')[1] : window.location.search.slice(1);
	var obj = {};

	if (queryString) {
		queryString = queryString.split('#')[0];
		var arr = queryString.split('&');

		for (var i = 0; i < arr.length; i++) {
			var a = arr[i].split('=');
			var paramName = a[0];
			var paramValue = typeof (a[1]) === 'undefined' ? true : a[1];

			paramName = paramName.toLowerCase();
			if (typeof paramValue === 'string') paramValue = paramValue.toLowerCase();

			if (paramName.match(/\[(\d+)?\]$/)) {
				var key = paramName.replace(/\[(\d+)?\]/, '');
				if (!obj[key]) obj[key] = [];

				if (paramName.match(/\[\d+\]$/)) {
					var index = /\[(\d+)\]/.exec(paramName)[1];
					obj[key][index] = paramValue;
				} else {
					obj[key].push(paramValue);
				}
			} else {
				if (!obj[paramName]) {
					obj[paramName] = paramValue;
				} else if (obj[paramName] && typeof obj[paramName] === 'string') {
					obj[paramName] = [obj[paramName]];
					obj[paramName].push(paramValue);
				} else {
					obj[paramName].push(paramValue);
				}
			}
		}
	}

	return obj;
}
// ==============================================
// -------------------------- $$$$$$$$$$$$$$$$$$$$$$$ ----------------------------------------------
// carrinho

let valorTotal = 0;
var itens = [];

function Erro() {
	$("#MisturaErro").html("<br>Selecione uma mistura")
}

function GetCookie(cookie) {
	return $.cookie(cookie) != null ? $.cookie(cookie) : null;
}

function SetCookie(cookie, obj) {
	$.cookie(cookie, JSON.stringify(obj), { path: '/', expires: 7 });
}

function RemoveCookie(cookie) {
	$.removeCookie(cookie);
}

function VerificaMistura() {
	if (document.querySelector('input[name="misturaId"]:checked') == null) {
		Erro();
		return true;
	}
	return false;

}

$(document).ready(function () {
	var cliente = GetCookie('cliente');
	var cart = GetCookie('carrinho');
	if (cart != null) itens = $.parseJSON(cart);
	if (cliente == null) SetCookie('cliente', GetCliente())
	ExibeCart();
});

function AddCarrinho() {
	if (VerificaMistura() == true) return false;
	$("#MisturaErro").html("")

	var StringMistura = document.querySelector('input[name="misturaId"]:checked');
	var StringSalada = document.querySelector('input[name="saladaId"]:checked');
	// let acrescimo = StringMistura.attributes[0].value;	
	let acrescimo = parseInt(StringMistura.attributes.acrescimo.nodeValue);

	let misturaId = StringMistura.defaultValue;
	let mistura = StringMistura != null ? StringMistura.id : null;
	let salada = StringSalada != null ? StringSalada.id : null;
	let acompanhamentos = [];
	let checks = $("input[name='selectAcompanhamentos']:checked");
	$.each(checks, function (i) {
		acompanhamentos.push(
			{
				"id": $(this).val(),
				"nome": checks[i].id
			}
		);
	});
	let saladaId = document.querySelector('input[name="saladaId"]:checked') != null ? document.querySelector('input[name="saladaId"]:checked').defaultValue : null;
	let tamanho = document.getElementById("tamanho").value;
	let valorUnitario = tamanho == 0 ? 12 + acrescimo : 14 + acrescimo;
	var observacao = document.getElementById("obs").value;


	itens.push(
		{
			"mistura": {
				"id": misturaId,
				"nome": mistura
			},
			"acompanhamentos": acompanhamentos.length != 0 ? acompanhamentos : [],
			"salada": {
				"id": saladaId != null ? saladaId : 0,
				"nome": salada != null ? salada : ""
			},
			"tamanho": tamanho,
			"observacao": observacao != null ? observacao : "",
			"valor": valorUnitario,
			"acrescimo": acrescimo != null ? acrescimo : ""
		}
	);

	RemoveCookie('carrinho');
	SetCookie('carrinho', itens);
	ExibeCart();
}


async function RemoveItem(position) {
	var exist = await itens.hasOwnProperty(position);
	if (exist) itens.splice(position, 1);
	RemoveCookie('carrinho');
	SetCookie('carrinho', itens);
	ExibeCart();
}

function ExibeCart() {
	valorTotal = 0.0;
	var badge = document.querySelector('.w3-badge');
	badge.innerHTML = itens.length;
	var wrapper = document.querySelector('.wrapper');
	let HTMLString = '';
	let acompanhamentos = '';
	let salada = '';
	if (itens.length > 0) {
		$(itens).each(function (index, value) {
			valorTotal += value.valor;
			acompanhamentos = value.acompanhamentos.length > 0 ? value.acompanhamentos[0].nome + ', ' + value.acompanhamentos[1].nome : 'Sem acompanhamentos ';
			salada = value.salada.nome != "" ? value.salada.nome : 'Sem salada';
			HTMLString += '<label><a href="#" onclick="RemoveItem(' + index + ');">'
			HTMLString += '<i class="fa fa-trash"></i></a> ' + value.mistura.nome + ', (' + acompanhamentos + '), ' + salada + ','
			HTMLString += '<b>R$' + value.valor + '</b></label><hr>';
		});

		valorTotal.toFixed(2);
		HTMLString += '<b>Total: R$ </b>' + valorTotal + '&nbsp; <a href="#" onclick="LimparCarrinho();" class="pull-rigth btn-link"> limpar carrinho <i class="fa fa-times"></i></a><br><br>';
		if (!VerificarSeBotaoExiste('#btn-finalizar')) CriarBotaoFinalizar();
	} else {
		HTMLString = '<span class="text-danger">Carrinho vazio</span><br><br>';
		DeletarBotaoFinalizar();
	}

	wrapper.innerHTML = HTMLString;
}

function LimparCarrinho() {
	itens = [];
	SetCookie('carrinho', itens);
	ExibeCart();
}

function CriarBotaoFinalizar() {
	if (itens.length > 0) createButton('btn-finalizar', 'btn btn-success', 'Finalizar', 'itens-carrinho');
}

function DeletarBotaoFinalizar() {
	var btnFinalizar = document.getElementById('btn-finalizar');
	btnFinalizar.parentNode.removeChild(btnFinalizar);
}

function VerificarSeBotaoExiste(id) {
	if ($(id).length) return true;
	return false;
}

function createButton(id, classe, texto, local) {
	var element = document.createElement("button");
	element.className = classe;
	element.id = id;
	element.onclick = function () {
		if (itens.length == 0) alert('carrinho vazio');
		$.ajax({
			dataType: "json",
			type: "POST",
			url: '/Marmita/Registro',
			data: {
				'marmitas': itens
			},
			success: function (dados) {
				itens = []
				ExibeCart();
				alert('Compra finalizada')
				 
			},
			error: function (error) {
				alert('Erro')
			}
		});
	};
	element.appendChild(document.createTextNode(texto));
	var page = document.getElementById(local);
	page.appendChild(element);
}

