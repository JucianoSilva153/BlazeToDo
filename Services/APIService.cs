using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazeToDo;

public class APIService
{
    public readonly string BaseURI = "http://localhost:5240";

    private ContaLogadaDTO conta = new ContaLogadaDTO();

    private HttpClient client;

    public APIService()
    {
        client = new HttpClient();
    }

    public async Task<bool> Autenticado()
    {
        try
        {
            var response = await client.GetAsync($"{BaseURI}/api/Conta/Autenticado");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return false;
            }
        }
        catch (System.Exception e)
        {
             Console.WriteLine(e.Message);
        }

        return false;
    }

    public async Task<bool> Autenticar(string Email, string Password)
    {
        try
        {
            var credenciais = new { email = Email, password = Password };

            var response = await client.PostAsJsonAsync(
                $"{BaseURI}/api/conta/autenticar",
                credenciais
            );

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadFromJsonAsync<RequestResponse>();

                if (resultado.Sucesso)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                        "Bearer",
                        resultado.Target.ToString()
                    );

                    if (await RetornarContaPeloEmail(Email))
                        return true;
                }
            }
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        return false;
    }

    private async Task<bool> RetornarContaPeloEmail(string email)
    {
        try
        {
            var response = await client.GetFromJsonAsync<RequestResponse>(
                $"{BaseURI}/api/Conta/PorEmail/{email}"
            );

            if (response.Sucesso)
            {
                conta = JsonSerializer.Deserialize<ContaLogadaDTO>(response.Target.ToString());

                if (conta is not null)
                    return true;
            }
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        return false;
    }

    public async Task<bool> CriarConta(AdicionarEditarContaDTO conta)
    {
        try
        {
            var response = await client.PostAsJsonAsync<AdicionarEditarContaDTO>(
                $"{BaseURI}/api/Conta",
                conta
            );

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        return true;
    }
}
