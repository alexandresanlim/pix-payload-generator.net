# PixPayloadGenerator.Net

<img width='200' src='https://user-images.githubusercontent.com/5353685/101644586-233eb080-3a14-11eb-9cec-2172586abfde.png'/>

[![Nuget](https://img.shields.io/nuget/dt/pix-payload-generator.net)](https://www.nuget.org/packages/pix-payload-generator.net)
[![Nuget](https://img.shields.io/nuget/v/pix-payload-generator.net)](https://www.nuget.org/packages/pix-payload-generator.net)

Este pacote implementa a geração de payloads para usar em QRCode estático PIX, usando como refrência o [manual de iniciação do pix 2.1](https://www.bcb.gov.br/content/estabilidadefinanceira/pix/Regulamento_Pix/II-ManualdePadroesparaIniciacaodoPix-versao2-1.pdf) página 6:

<img width='600' src='https://user-images.githubusercontent.com/5353685/101637003-e8844a80-3a0a-11eb-89a0-1ffd84d02d1c.png' />

# Como usar?

Basta criar uma instância de Payload, usando como parâmetros a chave pix, valor, id de identificação da transação e informações do títular da conta.

```csharp
var payload = new Payload("bee05743-4291-4f3c-9259-595df1307ba1", 00.50m, "Um-Id-Qualquer", new Merchant("Alexandre Lima", "Presidente Prudente"));
```

Em seguida gerar:

```csharp
var stringToQrCode = payload.Generate();
```

Retornara uma string conforme os valores setados, algo parecio com isso:

```
00020126580014br.gov.bcb.pix0136bee05743-4291-4f3c-9259-595df1307ba1520400005303986540510.005802BR5914Alexandre Lima6019Presidente Prudente62180514Um-Id-Qualquer6304D475
```

Enfim, basta setar em um QRCode! ;)


Este projeto possuí testes, onde poderá ser usado para colocar os valores que quiser, em sequência poderá copiar para um site [como este](https://pix.nascent.com.br/tools/pix-qr-decoder/) para ver o QrCode.
