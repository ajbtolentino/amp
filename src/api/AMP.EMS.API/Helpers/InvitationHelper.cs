namespace AMP.EMS.API.Helpers;

public static class InvitationHelper
{
    public static string GenerateCode(int length = 5)
    {
        var rand = new Random();

        // Choosing the size of string 
        // Using Next() string 
        var str = string.Empty;
        for (var i = 0; i < length; i++)
        {
            // Generating a random number. 
            var randValue = rand.Next(0, 26);

            // Generating random character by converting 
            // the random number into character. 
            var letter = Convert.ToChar(randValue + 65);

            // Appending the letter to string. 
            str += letter;
        }

        return str;
    }
}