# PixPayloadGenerator.Net

<img width='200' src='https://user-images.githubusercontent.com/5353685/101644586-233eb080-3a14-11eb-9cec-2172586abfde.png'/>

[![Nuget](https://img.shields.io/nuget/dt/pix-payload-generator.net)](https://www.nuget.org/packages/pix-payload-generator.net)
[![Nuget](https://img.shields.io/nuget/v/pix-payload-generator.net)](https://www.nuget.org/packages/pix-payload-generator.net)

Este pacote auxilia na geração de payloads para usar em QRCode estático PIX (Sistema de pagamento instântaneo do Brasil)

# Como usar?

### 1 - Instale [este pacote](https://www.nuget.org/packages/pix-payload-generator.net) na sua aplicação.

### 2 - Crie uma instância de Cobrança usando como parâmetros a chave pix, em seguida converta para um Payload passando como parâmetro o id de identificação da transação e informações do títular da conta.

```csharp
var cobranca = new Cobranca(_chave: "bee05743-4291-4f3c-9259-595df1307ba1");
var payload = cobranca.ToPayload("O-TxtId-Aqui", new Merchant("Alexandre Sanlim", "Presidente Prudente"));
```

#### Propriedades opcionais:
- Valor (Caso não informado, ficará livre para o pagador digitar o valor);
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

var payload = cobranca.ToPayload("O-TxtId-Aqui", new Merchant("Alexandre Sanlim", "Presidente Prudente"));
```

### 3 - A partir do Payload gerado crie uma string para setar no QrCode:

```csharp
var stringToQrCode = payload.GenerateStringToQrCode();
```

Retornará uma string como esta:

```
00020126580014br.gov.bcb.pix0136bee05743-4291-4f3c-9259-595df1307ba1520400005303986540510.005802BR5914Alexandre Lima6019Presidente Prudente62180514Um-Id-Qualquer6304D475
```

### 4 - Por fim, basta setar em um QRCode! ;)

<img src='https://dyn-qrcode.vercel.app/api?url=00020126580014br.gov.bcb.pix0136bee05743-4291-4f3c-9259-595df1307ba1520400005303986540510.005802BR5914Alexandre%20Lima6019Presidente%20Prudente62180514Um-Id-Qualquer6304D475' />

Este projeto possuí teste, onde poderá ser usado para colocar os valores que quiser, em seguida copiar a string gerada para um site [como este](https://pix.nascent.com.br/tools/pix-qr-decoder/) para validar e ver o QrCode.
