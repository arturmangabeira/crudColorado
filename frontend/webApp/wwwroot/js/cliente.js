const rotaClienteMVC = "https://localhost:7218/Home";

function obterTodosCliente()
{
    $.ajax({ 
        type: 'GET', 
        url: rotaClienteMVC + "/obter-todos",         
        dataType: 'json',
        beforeSend: function (){
            $(".table").LoadingOverlay("show");
        },
        success: function (data) { 
            $('#trCliente').empty();

            $.each(data, function(index, element) {
                
                let dataInsercao = new Date(element.dataInsercao).toLocaleString().split(',')[0]; 

                let tr = 
                '<tr>' +
                    '<td>'+element.codigoCliente+'</td>' +
                    '<td>'+element.nome+'</td>' +
                    '<td>'+element.endereco+'</td>' +
                    '<td>'+element.cidade+'</td>' +
                    '<td>'+element.uf+'</td>' +
                    '<td>'+dataInsercao+'</td>' +
                    '<td>' +
                        '<a href="/Home/Visualizar/'+element.codigoCliente+'" class="view" title="View" data-toggle="tooltip"><i class="material-icons">&#xE417;</i></a>' +
                        '<a href="/Home/Editar/'+element.codigoCliente+'" class="edit" title="Edit" data-toggle="tooltip"><i class="material-icons">&#xE254;</i></a>' +
                        '<a href="#" codigoCliente="'+element.codigoCliente+'" class="delete" title="Delete" data-toggle="tooltip"><i class="material-icons">&#xE872;</i></a>' +
                    '</td>' +
                '</tr>';

                $('#trCliente').append(tr);
                $(".table").LoadingOverlay("hide", true);
            });

            eventExcluirCliente();
        }
    });

    
}

function eventExcluirCliente()
{
    $(".delete").on("click", function(event){
        event.stopPropagation();
        let codigoCliente = $(this).attr("codigoCliente");
        var result = confirm("Deseja excluir o cliente de codigo: " + codigoCliente + " ?");

        if(result)
        {
            enviarDadosClienteExcluir(codigoCliente);
        }
    });
}

function keyPressClientePorNome()
{
    $("#nomeCliente").on('keypress',function(e) {
        let nome = $(this).val();
        
        if(nome.length > 2)
        {            
          obterClientePorFiltro(nome);  
          return;
        }
        
        obterTodosCliente();
    });
}

function obterClientePorFiltro(pnome)
{
    $.ajax({ 
        type: 'GET', 
        url: rotaClienteMVC + "/obter-cliente-por-filtro",
        data: {nome: pnome},         
        dataType: 'json',
        beforeSend: function (){
            $(".table").LoadingOverlay("show");
        },
        success: function (data) { 
            $('#trCliente').empty();

            $.each(data, function(index, element) {

                let dataInsercao = new Date(element.dataInsercao).toLocaleString().split(',')[0]; 

                let tr = 
                '<tr>' +
                    '<td>'+element.codigoCliente+'</td>' +
                    '<td>'+element.nome+'</td>' +
                    '<td>'+element.endereco+'</td>' +
                    '<td>'+element.cidade+'</td>' +
                    '<td>'+element.uf+'</td>' +
                    '<td>'+dataInsercao+'</td>' +
                    '<td>' +
                        '<a href="#" class="view" title="View" data-toggle="tooltip"><i class="material-icons">&#xE417;</i></a>' +
                        '<a href="#" class="edit" title="Edit" data-toggle="tooltip"><i class="material-icons">&#xE254;</i></a>' +
                        '<a href="#" class="delete" title="Delete" data-toggle="tooltip"><i class="material-icons">&#xE872;</i></a>' +
                    '</td>' +
                '</tr>';

                $('#trCliente').append(tr);
                $(".table").LoadingOverlay("hide", true);
            });
        }
    });
}


function salvarCliente()
{
    $("#btnCadastrar").on("click", function(){
        let form = $("form.cadastro").serialize();                
        enviarDadosClienteSalvar(form);
    }); 
}

function editarCliente(codigoCliente)
{
    obterClientePorCodigoCliente(codigoCliente);
    $("#btnEditar").on("click", function(){
        let form = $("form.cadastro").serialize();                
        enviarDadosClienteEditar(form);
    });
}

function enviarDadosClienteSalvar(form)
{
    $.ajax({ 
        type: 'POST', 
        url: rotaClienteMVC + "/inserir-cliente",
        data: form,
        dataType: "json",
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',                      
        encode: true,        
        beforeSend: function (){
            $(".cadastro").LoadingOverlay("show");
        },
        success: function (data) {             
            $(".cadastro").LoadingOverlay("hide", true);
            $("#menssagem").empty();                                
            $("#menssagem").append(
                '<div class="alert alert-success" role="alert">Registro Editado com sucesso !</div>'
            );

            var voltar = function (){
                window.location.href = "/Home";
            };
            setTimeout(() => {
                voltar();
            }, 1000);         
        },
        error: function(data)
        {            
            $("#menssagem").empty();
            $("#menssagem").append(
                '<div class="alert alert-danger" role="alert">'+
                    'Erro ao tentar atualizar o registro.'+
                '</div>'
            );           

            $(".cadastro").LoadingOverlay("hide", true);
        }
    });
}

function enviarDadosClienteEditar(form)
{    
    $.ajax({ 
        type: 'POST', 
        url: rotaClienteMVC + "/atualizar-cliente",
        data: form,
        dataType: "json",
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',                      
        encode: true,        
        beforeSend: function (){
            $(".cadastro").LoadingOverlay("show");
        },
        success: function (data) {             
            $(".cadastro").LoadingOverlay("hide", true);
            $("#menssagem").empty();                                
            $("#menssagem").append(
                '<div class="alert alert-success" role="alert">Registro Editado com sucesso !</div>'
            );

            var voltar = function (){
                window.location.href = "/Home";
            };
            setTimeout(() => {
                voltar();
            }, 1000);
            
        },
        error: function(data)
        {            
            $("#menssagem").empty();
            $("#menssagem").append(
                '<div class="alert alert-danger" role="alert">'+
                    'Erro ao tentar atualizar o registro.'+
                '</div>'
            );           

            $(".cadastro").LoadingOverlay("hide", true);
        }
    });
}

function enviarDadosClienteExcluir(codigoCliente)
{
    $.ajax({ 
        type: 'POST', 
        url: rotaClienteMVC + "/excluir-cliente?codigoCliente=" + codigoCliente,        
        dataType: 'json',
        beforeSend: function (){
            $(".table").LoadingOverlay("show");
        },
        success: function (data) { 
            $('#trCliente').empty();
            $(".table").LoadingOverlay("hide", true);
            obterTodosCliente();
        },
        error: function(data)
        {            
            $("#errors").append(
                '<div class="alert alert-danger" role="alert">'
                    + data.responseJSON.ErrorMessage + 
                '</div>'
            );           

            $(".table").LoadingOverlay("hide", true);
        }
    });
}

function obterClientePorCodigoCliente(codigoCliente)
{
    $.ajax({ 
        type: 'GET', 
        url: rotaClienteMVC + "/obter-cliente-por-codigo-cliente",
        data: {CodigoCliente: codigoCliente},         
        dataType: 'json',
        beforeSend: function (){
            $(".table").LoadingOverlay("show");
        },
        success: function (data) { 
            $('#trCliente').empty();

            $.each(data, function(index, element) {
                
                $('form[name="cadastro"]').find(':input').map(function(){
                    var name = $(this).prop("name");
                    if(name == index)
                    {
                        $(this).val(element);
                    }

                });

                $(".table").LoadingOverlay("hide", true);
            });
        }
    });
}