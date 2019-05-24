var acc = document.getElementsByClassName("accordion");
var i;
//collapse


for (i = 0; i < acc.length; i++) {
    acc[i].addEventListener("click", function () {
        this.classList.toggle("active");
        var panel = this.nextElementSibling;
        if (panel.style.maxHeight) {
            panel.style.maxHeight = null;
        } else {
            panel.style.maxHeight = panel.scrollHeight + "px";
        }
    });
}


var tel = null;

$(document).ready(SearchFilter());

function SearchFilter() {
    $('input[type=radio][name=status]').click(function () {
        let status = $('input[type=radio][name=status]:checked').val();
        if (status != undefined) SendController(status);
    });
}

$(".celular").keyup(function () {
    if ($('.celular').val().length > 0) {
        $("button[type=submit][name=close]").css("display", "block");
    } else {
        $("button[type=submit][name=close]").css("display", "none");
    }
});

$(".limparInput").click(function () {
    LimparTelefone();
    $("button[type=submit][name=close]").css("display", "none");
});

//mascara telefone/celular          
$(".celular").keypress(async function (e) {
    if ($(this).val().length < 15) {
        $('.celular').mask('(00) 0000-00009');
        if ($(this).val().length === 13) {
            await $('.celular').mask('(00) 0000-0000');
            tel = $(this).val();
        } else if ($(this).val().length === 14) {
            await $('.celular').mask('(00) 90000-0009');
            tel = $(this).val();
        }
    }
});

function GetStatus() {
    return $('input[type=radio][name=status]:checked').val();
}

function GetTelefone() {
    return $("#telefone").val();
}

$(".celular").blur(function (e) {
    if ($(this).val().length === 13 || $(this).val().length === 14) {
        //var status = $('input[type=radio][name=status]:checked').val();
        if (GetStatus() != undefined) SendController(GetStatus());
        else alert('Selecione uma das oções');
    }
});

function SendController(status) {
    var telefone = GetTelefone();
    $.ajax({
        type: "POST",
        url: "/Pedido/_Pedidos",
        data: {
            'Key': status,
            'Telefone': telefone
        },
        //data: { Key: status, Telefone: telefone },
        success: function (data) {
            $("#pedidos").html(data);
            $("#pedidos").css("display", "none");
            $("#pedidos").fadeIn(600);
        },
        error: function () {
            alert("ERro");
        }
    });
}

function LimparTelefone() {
    $('.celular').val('');
}