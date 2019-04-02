$(".excluirCliente").click(function() {
  let id = $(this).attr("rel");
  swal({
    title: "Você tem certeza?",
    text: "Depois de deletado não há mais volta!",
    icon: "warning",
    buttons: true,
    dangerMode: true
  }).then(willDelete => {
    if (willDelete) {
      DeletarClienteById(id);
    } else {
      swal("Certo, cliente não foi deletado!");
    }
  });
});

async function DeletarClienteById(id) {
  $.ajax({
    dataType: "json",
    type: "POST",
    url: "/Cliente/Delete",
    data: {
      Id: id
    },
    success: await function(dados) {
      swal("Pronto, cliente " + dados.nome + " deletado!", {
        icon: "success"
      }).then(ok => {
        if (ok) {
          Reload();
        } else {
          Reload();
        }
      });
    },
    error: swal("Opa!", "Esse cliente não existe!", "warning")
  });
}

function Reload() {
  setTimeout(() => location.reload(), 500);
}
