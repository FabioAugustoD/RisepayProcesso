$(document).ready(function () {
    $('#btnAdicionarNovo').click(function () {
        $('#modalAdicionar').modal('show');
        limparCamposModal();
        carregarCargos();
        configurarBotaoCriar();
    });

    function configurarBotaoCriar() {        
        $('#btnCriarColaborador').off('click').on('click', function () {
            var nome = $('#nome').val();
            var email = $('#email').val();
            var telefone = $('#telefone').val();
            var cargoId = $('#cargo').val();

            if (!validarEmail(email)) {
                mostrarErroEmail('Email inválido');
                return;
            }   
            
            $.ajax({
                url: 'https://localhost:7107/api/colaboradores',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify({
                    nome: nome,
                    email: email,
                    telefone: telefone,
                    idcargo: cargoId
                }),
                success: function (data) {                                    
                    $('#modalAdicionar').modal('hide');
                    location.reload();
                },
                error: function (error) {                    
                }
            });
        });
    }

    function configurarBotaoAtualizar(colaboradorId) {
        $('#btnCriarColaborador').off('click').on('click', function () {
            var nome = $('#nome').val();
            var email = $('#email').val();
            var telefone = $('#telefone').val();
            var cargoId = $('#cargo').val();

            if (!validarEmail(email)) {
                mostrarErroEmail('Email inválido');
                return;
            }

            var dados = {
                nome: nome,
                email: email,
                telefone: telefone,
                idcargo: cargoId
            };

            $.ajax({
                url: 'https://localhost:7107/api/colaboradores/' + colaboradorId,
                type: 'PUT',
                contentType: 'application/json',
                data: JSON.stringify(dados),
                success: function (data) {                    
                    $('#modalAdicionar').modal('hide');
                    location.reload();
                },
                error: function (error) {                    
                    console.error('Erro ao atualizar colaborador:', error);
                }
            });
        });
    }

    function limparCamposModal() {
        $('#nome').val('');
        $('#email').val('');
        $('#telefone').val('');
        $('#cargo').val('');
        ocultarErroEmail();
    }


    function validarEmail(email) {
        var re = /^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}$/;
        return re.test(email);
    }

    function mostrarErroEmail(mensagem) {
        $('#erroEmail').text(mensagem).show();
    }

    function ocultarErroEmail() {
        $('#erroEmail').hide();
    }

    $('#email').on('input', function () {
        ocultarErroEmail();
    });
   
    function carregarCargos(selectedCargoId) {
        $.ajax({
            url: 'https://localhost:7107/api/cargo',
            type: 'GET',
            success: function (data) {
                var options = '';
                $.each(data, function (index, item) {
                    options += '<option value="' + item.id + '">' + item.nome + '</option>';
                });
                $('#cargo').html(options);

                if (selectedCargoId) {
                    $('#cargo').val(selectedCargoId);
                }
            },
            error: function (error) {
                
            }
        });
    }

    $(document).on('click', '.btn-editar', function () {
        var colaboradorId = $(this).data('id');
        $('#modalAdicionar').modal('show');        
        $('#btnCriarColaborador').text('Atualizar');
        $('#modalAdicionarLabel').text('Editar Colaborador');
        
        $('#nome').val('');
        $('#email').val('');
        $('#telefone').val('');
        $('#cargo').val('');
        $('#colaboradorId').val(colaboradorId); 
        
        carregarDetalhesDoColaborador(colaboradorId);
        
        configurarBotaoAtualizar(colaboradorId);
    });

    function carregarDetalhesDoColaborador(colaboradorId) {
        $.ajax({
            url: 'https://localhost:7107/api/colaboradores/' + colaboradorId,
            type: 'GET',
            success: function (data) {                
                $('#nome').val(data.nome);
                $('#email').val(data.email);
                $('#telefone').val(data.telefone);
                
                carregarCargos(data.cargo.id);
            },
            error: function (error) {               
            }
        });
    }

    $('#btnBuscar').click(function () {
        var nome = $('input[name="searchString"]').val();

        $.ajax({
            url: 'https://localhost:7107/api/colaboradores/buscar?nome=' + nome,
            type: 'GET',
            success: function (data) {
                atualizarTabela(data);
            },
            error: function (error) {
                console.error('Erro ao buscar colaboradores:', error);
            }
        });
    });

    function atualizarTabela(colaboradores) {
        var tbody = $('table tbody');
        tbody.empty();

        $.each(colaboradores, function (index, colaborador) {
            var row = '<tr>' +
                '<td>' + colaborador.nome + '</td>' +
                '<td>' + colaborador.email + '</td>' +
                '<td>' + colaborador.telefone + '</td>' +
                '<td>' + colaborador.cargo.nome + '</td>' +
                '<td><button type="button" class="btn btn-primary btn-editar" data-id="' + colaborador.id + '">Editar</button></td>' +
                '</tr>';
            tbody.append(row);
        });
    }

    $('#modalAdicionar').on('hidden.bs.modal', function () {
        ocultarErroEmail();
        location.reload();
        $('#btnCriarColaborador').text('Criar');
        $('#modalAdicionarLabel').text('Adicionar Novo Colaborador');
    });
});
