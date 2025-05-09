document.addEventListener('DOMContentLoaded', () => {
    const urlParams = new URLSearchParams(window.location.search);
    const pessoaId = Number(urlParams.get('id'));

    document.getElementById('orcamentoForm').addEventListener('submit', async function (event) {
        event.preventDefault();

        const metrosQuadrados = Number(document.getElementById('metrosQuadrados').value);
        const numeroDePavimentos = Number(document.getElementById('numeroDePavimentos').value);
        const classificacao = Number(document.getElementById('classificacao').value);


        const imovelData = {
            pessoaId,
            metrosQuadrados,
            numeroDePavimentos,
            classificacao
        };

        try {
            const response = await fetch('https://localhost:7285/api/Orcamento/gerar-orcamento', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(imovelData)
            });

            if (!response.ok) {
                throw new Error('Erro ao gerar orçamento: ' + response.statusText);
            }

            const data = await response.json();
            console.log(data);
            document.getElementById('responseMessage').innerText = `Orçamento gerado com sucesso! Valor: R$${data.data}`;
        } catch (error) {
            document.getElementById('responseMessage').innerText = error.message;
        }
    });
});
