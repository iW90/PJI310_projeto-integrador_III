document.getElementById('pessoaForm').addEventListener('submit', async function (event) {
    event.preventDefault();

    const nomeCompleto = document.getElementById('nomeCompleto').value;
    const email = document.getElementById('email').value;
    const telefone = document.getElementById('telefone').value;
    const endereco = document.getElementById('endereco').value;

    const pessoaData = {
        nomeCompleto,
        email,
        telefone,
        endereco
    };

    try {
        const response = await fetch('https://localhost:7285/api/Pessoa/cadastrar-pessoa', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(pessoaData)
        });

        if (!response.ok) {
            throw new Error('Erro ao cadastrar: ' + response.statusText);
        }

        const data = await response.json();

        document.getElementById('responseMessage').innerText = `Cadastro realizado com sucesso! ID: ${data.data.pessoaId}`;
        window.location.href = `/Home/Orcamento?id=${data.data.pessoaId}`;
    } catch (error) {
        document.getElementById('responseMessage').innerText = error.message;
    }
});
