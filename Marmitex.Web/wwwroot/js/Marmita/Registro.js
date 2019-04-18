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

// carrinho


function Erro() {
	$("#MisturaErro").html("<br>Selecione uma mistura")
}

var itens = [];

function AddCarrinho() {
	var StringMistura = document.querySelector('input[name="misturaId"]:checked');

	let misturaId = StringMistura != null ? StringMistura.defaultValue : null;
	let mistura = StringMistura != null ? StringMistura.id : null;
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
	let salada = document.querySelector('input[name="saladaId"]:checked') != null ? document.querySelector('input[name="saladaId"]:checked').defaultValue : null;
	let tamanho = document.getElementById("tamanho").value;
	var observacao = document.getElementById("obs").value;

	if (misturaId == null) {
		Erro();
		return false;
	}
	$("#MisturaErro").html("")

	itens.push(
		{
			"misturaId": misturaId,
			"mistura": mistura,
			"acompanhamentos": acompanhamentos,
			"salada": salada,
			"tamanho": tamanho,
			"observacao": observacao
		}
	);
	// $.cookie("carrinho", itens);
	$.cookie("carrinho", JSON.stringify(itens), { path: '/', expires: 7 });





	console.log();
}



