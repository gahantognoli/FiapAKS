using Microsoft.AspNetCore.Mvc;

namespace FiapDocker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrevisaoTempoController : ControllerBase
    {
        private static readonly string[] CidadesBrasileiras = { "São Paulo", "Rio de Janeiro", "Brasília", "Salvador", "Belo Horizonte" };

        [HttpGet("condicoes-atuais")]
        public IEnumerable<PrevisaoTempo> ObterPrevisoesTempo()
        {
            var rng = new Random();
            var previsoes = new List<PrevisaoTempo>();

            foreach (var cidade in CidadesBrasileiras)
            {
                var temperaturaC = rng.Next(15, 35);
                previsoes.Add(new PrevisaoTempo
                {
                    Cidade = cidade,
                    Data = DateTime.Now,
                    TemperaturaC = temperaturaC,
                    Resumo = ObterResumo(temperaturaC)
                });
            }

            return previsoes;
        }

        [HttpGet("previsao-cinco-dias")]
        public IEnumerable<PrevisaoTempo> ObterPrevisaoCincoDias()
        {
            var rng = new Random();
            var previsoes = new List<PrevisaoTempo>();

            foreach (var cidade in CidadesBrasileiras)
            {
                for (int i = 0; i < 5; i++) 
                {
                    var temperaturaC = rng.Next(15, 35);
                    previsoes.Add(new PrevisaoTempo
                    {
                        Cidade = cidade,
                        Data = DateTime.Now.AddDays(i),
                        TemperaturaC = temperaturaC,
                        Resumo = ObterResumo(temperaturaC)
                    });
                }
            }

            return previsoes;
        }

        private static string ObterResumo(int temperaturaC)
        {
            return temperaturaC switch
            {
                var temp when temp < 0 => "Congelante",
                var temp when temp < 5 => "Friozinho",
                var temp when temp < 10 => "Frio",
                var temp when temp < 15 => "Frio agradavel",
                var temp when temp < 20 => "Agradável",
                var temp when temp < 25 => "Moderado",
                var temp when temp < 30 => "Calor",
                _ => "Muito Calor",
            };
        }
    }
}