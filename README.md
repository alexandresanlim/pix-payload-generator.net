# PIX - Payload generator DotNet

<img width='200' src='https://user-images.githubusercontent.com/5353685/101644586-233eb080-3a14-11eb-9cec-2172586abfde.png'/>

[![Nuget](https://img.shields.io/nuget/dt/pix-payload-generator.net)](https://www.nuget.org/packages/pix-payload-generator.net)
[![Nuget](https://img.shields.io/nuget/v/pix-payload-generator.net)](https://www.nuget.org/packages/pix-payload-generator.net)

Este pacote auxilia na geração de payloads para usar em QRCode estático PIX.

# ⚠ Informações importantes
- Não requer um PSP
- Não necessita de conexão com a internet
- Não é possivel recuperar informações do status de pagamento, use [este pacote](https://github.com/alexandresanlim/pix-dynamic-payload-generator.net) caso necessite disso.
- Não é possivel pagar para si mesmo usando a mesma Chave x PSP, ex: gerar um QrCode para uma chave na Nubank e tentar pagar com a própria conta da Nubank.
- O QrCode/Código copia e cola gerado, pode ser reaproveitado para vários pagamentos.

# Como usar?

1 - Instale [este pacote](https://www.nuget.org/packages/pix-payload-generator.net) na sua aplicação.
```
Install-Package pix-payload-generator.net
```

2 - Crie uma instância de Cobrança passando por parâmetro a chave pix.

```csharp
var cobranca = new Cobranca(_chave: "bee05743-4291-4f3c-9259-595df1307ba1");
```

#### Você pode optar por adicionar mais algumas informações:
- Valor (Caso não informado, ficará livre para o pagador digitar);
- Descriçao (Caso informado, aparecerá no momento do pagamento).

Exemplo, definindo o valor de R$ 15,00 e descrição "Pagamento do pedido X":
```csharp
Cobranca cobranca = new Cobranca(_chave: "bee05743-4291-4f3c-9259-595df1307ba1")
{
    SolicitacaoPagador = "Pagamento do Pedido X",
    Valor = new Valor
    {
        Original = "15.00"
    }
};

```

#### ATENÇÃO! Os valores de "Original" devem sempre seguir o padrão de duas casas decimais separadas por ".", ex:

R$ 10.000,00 = "10000.00"<br/>
R$ 1.000,00 = "1000.00"<br/>
R$ 100,00 = "100.00"<br/>
R$ 10,00 = "10.00"<br/>
R$ 1,00 = "1.00"<br/>
R$ 0,90 = "0.90"

#### Os bancos tem limites de valores a ser transferido por Pix, verifique o limite para o seu antes de transferir um valor.

3 - Gerar o Payload a partir da cobrança criada
```csharp
var payload = cobranca.ToPayload("O-TxtId-Aqui", new Merchant("Alexandre Sanlim", "Presidente Prudente"));
```

4 - Pegar uma string para setar em um QrCode a partir do Payload gerado


```csharp
var stringToQrCode = payload.GenerateStringToQrCode();
```

Retornará uma string como esta:

```
00020126580014br.gov.bcb.pix0136bee05743-4291-4f3c-9259-595df1307ba1520400005303986540510.005802BR5914Alexandre Lima6019Presidente Prudente62180514Um-Id-Qualquer6304D475
```

5 - Por fim, basta setar em um QRCode! ;)

<img src='https://dyn-qrcode.vercel.app/api?url=00020126580014br.gov.bcb.pix0136bee05743-4291-4f3c-9259-595df1307ba1520400005303986540510.005802BR5914Alexandre%20Lima6019Presidente%20Prudente62180514Um-Id-Qualquer6304D475' />

# Testes
- Este projeto possuí [testes](https://github.com/alexandresanlim/pix-payload-generator.net/blob/master/pix-payload-generator.net-test/UnitTest1.cs), onde poderão ser usados para colocar os valores que quiser e gerar seus payloads. 
- Copie a string gerada para [este site](https://pix.nascent.com.br/tools/pix-qr-decoder/) para validar e ver o QrCode.

# Extra
- Caso necessite das funções de QrCode dinâmico, onde é possível acompanhar o status de pagamento e conectar com as funções disponíveis na [pix-api](https://bacen.github.io/pix-api/) use [este pacote](https://github.com/alexandresanlim/pix-dynamic-payload-generator.net).
