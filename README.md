# DynuSharp
<img width="64" height="auto" src="icon.png">

[![DynuSharp](https://img.shields.io/nuget/vpre/DynuSharp.svg?cacheSeconds=3600&label=DynuSharp%20nuget)](https://www.nuget.org/packages/DynuSharp)
[![NuGet](https://img.shields.io/nuget/dt/DynuSharp.svg?cacheSeconds=3600&label=Downloads)](https://www.nuget.org/packages/DynuSharp)

## Thanks to Dynu
A big thanks to Dynu for offering such a versatile platform that spans beyond DNS services to include email, domain registration, and more. Their provision of a free tier is a testament to their commitment to making powerful web solutions accessible to everyone. Check out [Dynu's website](https://www.dynu.com) for more information on their services.

## Overview
DynuSharp is a .NET library designed to facilitate seamless integration with Dynu's API, enabling developers to manage DNS, email, domain services, and more with utmost efficiency and security. This library leverages .NET's robust features to provide an intuitive interface for Dynu services, ensuring sensitive credentials are handled securely.

## Features
- **Comprehensive API Coverage**: Interact with Dynu's DNS, Email, and Domain services through a single, cohesive library.
- **Secure Secret Management**: Implements advanced techniques to securely store and manage runtime secrets, including secure memory storage, obfuscation, and TPM-based solutions.
- **Flexible Authentication**: Out-of-the-box support for API key and OAuth2, with the ability to extend or implement custom authentication mechanisms.

### Authentication
DynuSharp offers built-in support for standard Dynu authentication methods (API key and OAuth2) and extends the capability to include custom authentication strategies through the 'IAuthentication' interface.<br/>
<br/>
For API credentials management, visit [Dynu API Credentials](https://www.dynu.com/en-US/ControlPanel/APICredentials).

### Standard Authentication Methods

#### API Key Authentication
```cs
var apiKey = "your_api_key_here";
var client = new DynuClient(apiKey);
```

#### OAuth2 Authentication
```cs
var clientId = "your_client_id_here";
var secret = "your_client_secret_here";
var client = new DynuClient(clientId, secret);
```

#### Custom Authentication
DynuSharp's design embraces extensibility, allowing developers to implement their own authentication mechanisms by implementing the IAuthentication interface.
```cs
public class CustomAuthentication : IAuthentication
{
    // Implementation of custom authentication logic
}

var customAuth = new CustomAuthentication();
var client = new DynuClient(customAuth);
```

#### Secure Secret Management
DynuSharp secures sensitive information such as API keys, client secrets, and client IDs using AES encryption as standard practice. Encrypted data is stored and utilized in-memory, leveraging TPM module technology when available for enhanced security. As a fallback, obfuscation techniques are employed to slightly increase security. No secrets are permanently stored, ensuring they remain accessible only for the duration of the client's lifespan. While these measures significantly enhance the protection of sensitive information, it's acknowledged that no system can guarantee 100% security.

## Example
Here's a quick demonstration of DynuSharp in action:
```cs
using var client = new DynuClient("api_key");
var dnsDomains = await client.DNS.Domains.GetListAsync();
foreach (var domain in dnsDomains)
{
    var records = await client.DNS.Records.GetListAsync(domain.Id);
    foreach (var record in records)
    {
        Console.WriteLine(record);
    }
}
```
This code snippet highlights how DynuSharp makes it straightforward to interact with Dynu's API, streamlining the process of managing DNS records with ease and efficiency.

# DynuSharp.HttpTest Example
For a practical demonstration of **'DynuSharp'** in action, check out the [DynuSharp.HttpTest console application](https://github.com/CwistSilver/DynuSharp.HttpTest). This companion project serves as both a testing framework and an example implementation, showcasing how to integrate and validate connectivity with Dynu API endpoints. Whether you're new to **'DynuSharp'** or looking for advanced usage examples, **'DynuSharp.HttpTest'** provides valuable insights into the library's capabilities.

## Contributing
Contributions to **'DynuSharp'** are welcome. Follow these steps to contribute:

1. Fork the Project
2. Create your Feature Branch (git checkout -b feature/YourFeature)
3. Commit your Changes (git commit -m 'Add YourFeature')
4. Push to the Branch (git push origin feature/YourFeature)
5. Open a Pull Request

## Licence
**'DynuSharp'** is licenced under the [MIT licence](LICENSE.txt).

## Dependencies
**'DynuSharp'** utilizes the following packages, which need to be included as dependencies in your project:

- [Microsoft.TSS](https://github.com/microsoft/TPM-2.0-Parser)
- [Microsoft.Extensions.Http.Polly](https://www.nuget.org/packages/Microsoft.Extensions.Http.Polly)
