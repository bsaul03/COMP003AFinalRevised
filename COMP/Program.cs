
/*
* Author: Saul Barajas
* Course: COMP003A-L01
* Purpose: Final
*/
namespace COMP003AFinalRevised
{
    /// <summary>
    /// Main class of the program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method of the program.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Dating App - New User Profile Intake Form\n");

            // User Input Section
            string firstName = ValidateName("First Name");
            string lastName = ValidateName("Last Name");
            int birthYear = ValidateBirthYear();
            char gender = ValidateGender();

            // Questionnaire Section
            string[] questions = new string[]
            {
            "What is your favorite hobby?",
            "What is your favorite movie?",
            "Describe your ideal date?",
            "What are you looking for in a partner?",
            "What is your favorite travel destination?",
            "What is your favorite food?",
            "What are your pet peeves?",
            "What is your dream job?",
            "What are your long-term goals?",
            "What is something unique about yourself?"
            };

            // Purpose of the line below: Initialize an array to store user responses to questionnaire.
            // questions.Length returns the number of questions in the array.
            // questions.Length is used here to determine the size of the userResponses array.
            string[] userResponses = new string[questions.Length];

            // Purpose of the loop below: Iterate over each question, prompt the user for response, and store the response.
            // i < questions.Length checks if the loop index is within the bounds of the questions array.
            // i++ increments the loop index after each iteration.
            // The loop starts at 0 because array indices start from 0 in C#.
            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine(questions[i]);
                // Create a method that validates the user's response to ensure it is not null/empty/whitespace
                userResponses[i] = ValidateResponse(); // Validate user's response and store it
            }
            // Display Questionnaire Responses
            Console.WriteLine("\nQuestionnaire Responses:");
            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"Question {i + 1}: {questions[i]}");
                Console.WriteLine($"Response {i + 1}: {userResponses[i]}\n");
            } 
                // Profile Summary Section
                Console.WriteLine("\nProfile Summary:");
            Console.WriteLine($"Name: {lastName}, {firstName}");
            Console.WriteLine($"Age: {DateTime.Now.Year - birthYear}");
            Console.WriteLine($"Gender: {GetFullGenderDescription(gender)}\n");

            Console.WriteLine("Questionnaire Responses:");

            // Purpose of the loop below: Display each question along with the user's response.
            // i starts at 0 to correspond with the index of the first question.
            for (int i = 0; i < questions.Length; i++)
            {
                // i + 1 is used here to display question/response numbering starting from 1 for better readability.
                Console.WriteLine($"Question {i + 1}: {questions[i]}");
                // '\n' adds a new line for better formatting in the output.
                Console.WriteLine($"Response {i + 1}: {userResponses[i]}\n");
            }
        }
        /// <summary>
        /// Validates the user's first or last name.
        /// </summary>
        /// <param name="nameType">The type of name (first or last).</param>
        /// <returns>The validated first or last name.</returns>
        static string ValidateName(string nameType)
        {
            string name;
            do
            {
                Console.Write($"Enter {nameType}: ");
                // Trim() removes leading and trailing whitespace from the input.
                name = Console.ReadLine().Trim();
            } while (string.IsNullOrWhiteSpace(name) || ContainsNumbersOrSpecialCharacters(name)); // Loop continues if name is empty or contains invalid characters.

            return name;
        }

        /// <summary>
        /// Validates the user's birth year.
        /// </summary>
        /// <returns>The validated birth year.</returns>
        static int ValidateBirthYear()
        {
            int birthYear;
            do
            {
                Console.Write("Enter Birth Year: ");
                // TryParse attempts to parse the input string into an integer.
                // The out parameter stores the parsed integer value.
                int.TryParse(Console.ReadLine(), out birthYear);
            } while (birthYear < 1900 || birthYear > DateTime.Now.Year); // Loop continues if birth year is not within a valid range.

            return birthYear;
        }

        // Method does not contain parameters because it only validates the gender input.
        // The method validates and returns the user's gender.

        /// <summary>
        /// Validates the user's gender.
        /// </summary>
        /// <returns>The validated gender.</returns>
        static char ValidateGender()
        {
            char gender;
            do
            {
                Console.Write("Enter Gender (M/F/O): ");
                // ToUpper() converts the input to uppercase.
                char.TryParse(Console.ReadLine().ToUpper(), out gender);
            } while (gender != 'M' && gender != 'F' && gender != 'O'); // Loop continues if gender input is not valid.

            return gender;
        }

        /// <summary>
        /// Checks if the input string contains numbers or special characters.
        /// </summary>
        /// <param name="input">The input string to be checked.</param>
        /// <returns>True if the input contains numbers or special characters, otherwise false.</returns>
        static bool ContainsNumbersOrSpecialCharacters(string input)
        {
            // The loop iterates over each character in the input string.
            // char.IsDigit, char.IsSymbol, and char.IsPunctuation check if the character is a digit, symbol, or punctuation.
            foreach (char c in input)
            {
                if (char.IsDigit(c) || char.IsSymbol(c) || char.IsPunctuation(c))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns the full description of the user's gender based on the provided gender code.
        /// </summary>
        /// <param name="gender">The gender code (M, F, or O).</param>
        /// <returns>The full description of the user's gender.</returns>
        static string GetFullGenderDescription(char gender)
        {
            switch (gender)
            {
                case 'M':
                    return "Male";
                case 'F':
                    return "Female";
                case 'O':
                    return "Other";
                default:
                    return "Unknown"; // This line is there as a fail safe.
            }
       }
        /// <summary>
        /// Validates the user's response to ensure it is not null, empty, or whitespace.
        /// </summary>
        /// <returns>The validated user response.</returns>
        static string ValidateResponse()
        {
            string response;
            // Validate user's response to ensure it is not empty or whitespace
            do
            {
                response = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(response))
                {
                    Console.WriteLine("Response cannot be empty. Please provide a valid response.");
                }
            } while (string.IsNullOrWhiteSpace(response)); // Loop until a valid response is provided

            return response;
        }
    }
}
    
