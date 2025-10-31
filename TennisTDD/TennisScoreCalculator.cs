namespace TennisTDD;

public class TennisScoreCalculator
{
    public string Score(int player1Points, int player2Points)
    {
        if (player1Points == player2Points)
            return JugadoresEmpatados(player1Points);
        
        if (player1Points >= 4 || player2Points >= 4)
        {
            int diff = player1Points - player2Points;
            if (Math.Abs(diff) == 1)
                return JugadorEnVentaja(diff);
            return JugadorGanador(diff);
        }
        
        return $"{TraducirPuntaje(player1Points)}-{TraducirPuntaje(player2Points)}";
    }

    private string JugadorGanador(int diff)
    {
        if (diff >= 2)
            return "Victoria jugador Uno";
        return "Victoria jugador Dos";
    }

    private static string JugadorEnVentaja(int diff)
    {
        if (diff == 1)
            return "Ventaja jugador Uno";
        return "Ventaja jugador Dos";
    }

    private string JugadoresEmpatados(int player1Points)
    {
        if (player1Points >= 4)
            return "Deuce";
        return $"{TraducirPuntaje(player1Points)}-All";
    }

    public string TraducirPuntaje(int puntaje)
    {
        return puntaje switch
        {
            0 => "Love",
            1 => "Fifteen",
            2 => "Thirty",
            3 => "Forty",
            _ => ""
        };
    }
    
    
}