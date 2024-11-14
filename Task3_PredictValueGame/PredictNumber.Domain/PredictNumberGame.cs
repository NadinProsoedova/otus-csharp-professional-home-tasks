using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictNumber.Domain;

internal class PredictNumberGame
{
    private readonly RandomNumberProvider _numberProvider;

    private readonly NumberValidator _numberValidator;

    private int _destinationValue;

    public PredictNumberGame(RandomNumberProvider numberProvider, NumberValidator numberValidator)
    {
        _numberProvider = numberProvider;
        _numberValidator = numberValidator;
    }

    public void StartGame()
    {
        _destinationValue = _numberProvider.GetNumber();
    }

    public void Predict(int input)
    {
        var result = _numberValidator.Validate(input, _destinationValue);


    }
}
