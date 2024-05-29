$(document).ready(function () {
    $('#btnAdicionarNovo').click(function () {
        $('#modalAdicionar').modal('show');
        carregarCargos(); // Carregar lista de cargos quando o modal é aberto
        configurarBotaoCriar(); // Configurar botão para criação
    });

    function configurarBotaoCriar() {
        $('#btnCriarColaborador').off('click').on('click', function () {
            var nome = $('#nome').val();
            var email = $('#email').val();
            var telefone = $('#telefone').val();
            var cargoId = $('#cargo').val(); // Capturar o ID do cargo selecionado

            console.log('ID do Cargo Selecionado:', cargoId);

            // Enviar os dados do colaborador ao servidor
            $.ajax({
                url: 'https://localhost:7107/api/colaboradores',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify({
                    nome: nome,
                    email: email,
                    telefone: telefone,
                    idcargo: cargoId // Certifique-se de que o nome da propriedade está correto
                }),
                success: function (data) {
                    // Lidar com o sucesso                
                    $('#modalAdicionar').modal('hide');
                    location.reload(); // Recarregar a página
                },
                error: function (error) {
                    // Lidar com o erro
                }
            });
        });
    }

    // Função para carregar lista de cargos na combobox
    function carregarCargos() {
        $.ajax({
            url: 'https://localhost:7107/api/cargo',
            type: 'GET',
            success: function (data) {
                var options = '';
                $.each(data, function (index, item) {
                    options += '<option value="' + item.id + '">' + item.nome + '</option>';
                });
                $('#cargo').html(options);
            },
            error: function (error) {
                // Lidar com o erro
            }
        });
    }

    $(document).on('click', '.btn-editar', function () {
        var colaboradorId = $(this).data('id');
        $('#modalAdicionar').modal('show'); // Abre o modal de criação

        // Altere o texto do botão e o título do modal
        $('#btnCriarColaborador').text('Atualizar');
        $('#modalAdicionarLabel').text('Editar Colaborador');

        // Limpe os campos do formulário para evitar dados antigos
        $('#nome').val('');
        $('#email').val('');
        $('#telefone').val('');
        $('#cargo').val('');
        $('#colaboradorId').val(colaboradorId); // Armazena o ID do colaborador

        // Carregue os detalhes do colaborador no formulário de criação
        carregarDetalhesDoColaborador(colaboradorId);

        // Configurar botão para atualizar
        configurarBotaoAtualizar(colaboradorId);
    });

    function configurarBotaoAtualizar(colaboradorId) {
        $('#btnCriarColaborador').off('click').on('click', function () {
            // Capturar os valores dos campos do formulário
            var nome = $('#nome').val();
            var email = $('#email').val();
            var telefone = $('#telefone').val();
            var cargoId = $('#cargo').val(); // Capturar o ID do cargo selecionado

            // Criar o objeto de dados para enviar ao servidor
            var dados = {
                nome: nome,
                email: email,
                telefone: telefone,
                idcargo: cargoId
            };

            // Enviar uma solicitação AJAX PUT para atualizar os dados do colaborador
            $.ajax({
                url: 'https://localhost:7107/api/colaboradores/' + colaboradorId,
                type: 'PUT',
                contentType: 'application/json',
                data: JSON.stringify(dados),
                success: function (data) {
                    // Lidar com o sucesso da atualização
                    $('#modalAdicionar').modal('hide'); // Fechar o modal de edição
                    location.reload(); // Recarregar a página para refletir as alterações
                },
                error: function (error) {
                    // Lidar com erros de atualização
                    console.error('Erro ao atualizar colaborador:', error);
                }
            });
        });
    }

    function carregarDetalhesDoColaborador(colaboradorId) {
        // Faça uma solicitação AJAX para buscar os detalhes do colaborador com base no ID
        $.ajax({
            url: 'https://localhost:7107/api/colaboradores/' + colaboradorId,
            type: 'GET',
            success: function (data) {
                // Preencha os campos do formulário com os detalhes do colaborador
                $('#nome').val(data.nome);
                $('#email').val(data.email);
                $('#telefone').val(data.telefone);

                // Preencha o campo com o nome do cargo
                $('#cargo').append('<option value="' + data.cargo.id + '">' + data.cargo.nome + '</option>');
                $('#cargo').val(data.cargo.id); // Defina o valor selecionado no combobox
            },
            error: function (error) {
                // Lidar com o erro
            }
        });
    }
});
