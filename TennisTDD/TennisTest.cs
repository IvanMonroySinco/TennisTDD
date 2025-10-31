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
        var resultado = juego.Score(0,0);
        //Assert
        resultado.Should().Be("Love-All");
    }

    [Fact]
    public void DebeRetornarFifteenLove_Si_JugadorUnoTieneUnPuntoYJugadorDosTieneCeroPuntos()
    {
        //Arrange
        var juego = new TennisScoreCalculator();
        //Act
        var resultado = juego.Score(1,0);
        //Assert
        resultado.Should().Be("Fifteen-Love");
    }

    [Fact]
    public void DebeRetornarFifteenAll_Si_AmbosJugadoresTienenUnPunto()
    {
        //Arrange
        var juego = new TennisScoreCalculator();
        //Act
        var resultado = juego.Score(1,1);
        //Assert
        resultado.Should().Be("Fifteen-All");
    }
}

public class TennisScoreCalculator {
    
    public string Score(int player1Points, int player2Points)
    {
        if (player1Points == 1)
        {
            return "Fifteen-Love";
        }
        return "Love-All";
    }
}
