using Microsoft.JSInterop;

namespace BlazeToDo;

public class CookieService
{
    private static IJSRuntime js;

    public CookieService(IJSRuntime JS)
    {
        js = JS;
    }

    public async Task CriarCookie(string nome, string valor, double duracao = 0)
    {
        await js.InvokeVoidAsync("CriaCookie", nome, valor, duracao);
    }

    public async Task RemoverCookie(string nome)
    {
        await js.InvokeVoidAsync("RemoveCookie", nome);
    }

    public async Task<string> RetornarCookie(string nome)
    {
        return await js.InvokeAsync<string>("RetornaCookie", nome);
    }
}