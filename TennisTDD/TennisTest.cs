using FluentAssertions;

namespace TennisTDD;

public class TennisTest
{
    [Fact]
    public void DebeRetornarLoveAll_Si_AmbosJugadoresTienenCeroPuntos()
    {
        //Arrange
        var juego = new TennisScoreCalculator();
        //Act
        var resultado = juego.Score(0, 0);
        //Assert
        resultado.Should().Be("Love-All");
    }

    [Fact]
    public void DebeRetornarFifteenLove_Si_JugadorUnoTieneUnPuntoYJugadorDosTieneCeroPuntos()
    {
        //Arrange
        var juego = new TennisScoreCalculator();
        //Act
        var resultado = juego.Score(1, 0);
        //Assert
        resultado.Should().Be("Fifteen-Love");
    }

    [Fact]
    public void DebeRetornarFifteenAll_Si_AmbosJugadoresTienenUnPunto()
    {
        //Arrange
        var juego = new TennisScoreCalculator();
        //Act
        var resultado = juego.Score(1, 1);
        //Assert
        resultado.Should().Be("Fifteen-All");
    }

    [Fact]
    public void DebeRetornarThirtyFifteen_Si_JugadorUnoTieneDosPuntosYJugadorDosTieneUnPunto()
    {
        //Arrange
        var juego = new TennisScoreCalculator();
        //Act
        var resultado = juego.Score(2, 1);
        //Assert
        resultado.Should().Be("Thirty-Fifteen");
    }

    [Fact]
    public void DebeRetornarFortyAll_Si_AmbosJugadoresTienenTresPuntos()
    {
        //Arrange
        var juego = new TennisScoreCalculator();
        //Act
        var resultado = juego.Score(3, 3);
        //Assert
        resultado.Should().Be("Forty-All");
    }

    [Fact]
    public void DebeRetornarFortyThirty_Si_JugadorUnoTieneTresPuntosYJugadorDosTieneDosPuntos()
    {
        //Arrange
        var juego = new TennisScoreCalculator();
        //Act
        var resultado = juego.Score(3, 2);
        //Assert
        resultado.Should().Be("Forty-Thirty");
    }
    
    [Theory]
    [InlineData(4, 4)]
    [InlineData(6, 6)]
    [InlineData(8, 8)]
    [InlineData(9, 9)]
    public void DebeRetornarDeuce_Si_AmbosJugadoresTienenMasDeCuatroPuntosYEstanEmpatados(int player1Points, int player2Points)
    {
        //Arrange
        var juego = new TennisScoreCalculator();
        //Act
        var resultado = juego.Score(player1Points, player2Points);
        //Assert
        resultado.Should().Be("Deuce");
    }
    
    [Fact]
    public void DebeRetornarVentajaJugadorUno_Si_JugadorUnoTieneCincoPuntosYJugadorDosTieneCuatro()
    {
        //Arrange
        var juego = new TennisScoreCalculator();
        //Act
        var resultado = juego.Score(5,4);
        //Assert
        resultado.Should().Be("Ventaja jugador Uno");
    }

    [Fact]
    public void DebeRetornarVentajaJugadorDos_Si_JugadorUnoTieneCincoPuntosYJugadorDosTieneSeis()
    {
        //Arrange
        var juego = new TennisScoreCalculator();
        //Act
        var resultado = juego.Score(5,6);
        //Assert
        resultado.Should().Be("Ventaja jugador Dos");
    }
    
}

public class TennisScoreCalculator
{
    public string Score(int player1Points, int player2Points)
    {
        if (player1Points == 5)
        {
            return "Ventaja jugador Uno";
        }
        if (player1Points == player2Points)
        {
            if (player1Points >= 4)
                return "Deuce";
            return $"{TraducirPuntaje(player1Points)}-All";
        }
        
        return $"{TraducirPuntaje(player1Points)}-{TraducirPuntaje(player2Points)}";
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