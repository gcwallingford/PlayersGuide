namespace Exercise_27;

public class Validator
{
    public bool LengthValidation(string input)
    {
        bool lengthIsValid;
        if (input.Length >= 6  && input.Length <= 13)
        {
            lengthIsValid = true;
        }
        else
        {
            lengthIsValid = false;
        }

        return lengthIsValid;
    }

    public bool CharacterValidation(string input)
    {
        int upperCount = 0;
        int lowerCount = 0;
        int numCount = 0;
        int tCount = 0;
        int andCount = 0;

        bool charactersValid = false;
        
        foreach (char character in input)
        {
            if (char.IsUpper(character))
            {
                upperCount++;
            }
            else if (char.IsLower(character))
            {
                lowerCount++;
            }
            else if (char.IsDigit(character))
            {
                numCount++;
            }
            else if (character == 't' || character == 'T')
            {
                tCount++;
            }
            else if (character == '&')
            {
                andCount++;
            }
        }
        if (upperCount > 0
            && lowerCount > 0 
            && numCount > 0 
            && tCount == 0 
            && andCount == 0)
        {
            charactersValid = true;
        }

        return charactersValid;
    }

    public bool FullValidator(string input)
    {
        bool fullValid = false;
        bool lengthValid = LengthValidation(input);
        bool charValid = CharacterValidation(input);

        if (lengthValid == true && charValid == true)
        {
            fullValid = true;
        }
        else
        {
            fullValid = false;
        }

        return fullValid;
    }
}