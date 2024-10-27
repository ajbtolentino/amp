namespace AMP.EMS.API.Helpers;

public static class InvitationHelper
{
    public static string GenerateCode()
    {
        var rand = new Random();

        // Choosing the size of string 
        // Using Next() string 
        var stringlen = rand.Next(4, 10);
        var randValue = 0;
        var str = string.Empty;
        char letter;
        for (int i = 0; i < stringlen; i++)
        {

            // Generating a random number. 
            randValue = rand.Next(0, 26);

            // Generating random character by converting 
            // the random number into character. 
            letter = Convert.ToChar(randValue + 65);

            // Appending the letter to string. 
            str += letter;
        }

        return str;
    }
}