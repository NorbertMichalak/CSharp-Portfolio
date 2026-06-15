List<int> scores = [95, 72, 40, 88, 100];

while(true)
{
    
    ShowMenu();
    string? choice = Console.ReadLine();

    switch(choice)
    {
        case "1":
        Console.WriteLine("Enter a score to add:");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int newscore))
        {
            if (IsValidScore(newscore))
            {
                scores.Add(newscore);
                Console.WriteLine("Score added.");
            }
            else
            {
                Console.WriteLine("Score must be between 0-100.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input -not a number!");
        }

        break;

        case "2": 
        ShowScores(scores);
        break;

        case "3":
        Console.WriteLine("Enter a score to remove:");
        string? input2 = Console.ReadLine();

        if (int.TryParse(input2, out int scoreToRemove))
            {   
                //Remove() returns false if value not found
                if(!scores.Remove(scoreToRemove))
                
                    Console.WriteLine("Score not found.");
                else
                    Console.WriteLine("Score removed.");
            
            }
        else
            {
                Console.WriteLine("Invalid input - not a number!");
            }

        break;

        case "4":
        Console.WriteLine("Enter the score you want to replace.");

        if (!int.TryParse(Console.ReadLine(), out int oldValue))
        { Console.WriteLine("Invalid input - not a number."); 
        break; 
        } 
        
        int index = scores.IndexOf(oldValue); 
        
        if ( index == -1 ) 
        { 
        Console.WriteLine("Score not found in the list."); 
        break;
        } 
        
        Console.WriteLine("Enter a new score:"); 
        if(!int.TryParse(Console.ReadLine(),out int newValue))
        { 
        Console.WriteLine("Invalid input - not a number."); 
        break; 
        }

        if (!IsValidScore(newValue))
        {
        Console.WriteLine("Score must be between 0 and 100.");
        break;
        }
        
        scores[index] = newValue;
        Console.WriteLine("Updated list: " + string.Join(", ", scores ));

        break;

        case "5": return;

        case "6":
        ShowAverage(scores);
        break;

        case "7":
        ShowMaxScore(scores);
        break;

        case "8":
        ShowMinScore(scores);
        break;

    }
}

static void ShowMenu()
{
    Console.WriteLine("\nScore Management System");
    Console.WriteLine("1. Add score.");
    Console.WriteLine("2. Show scores.");
    Console.WriteLine("3. Remove score");
    Console.WriteLine("4. Update score");
    Console.WriteLine("5. Exit");
    Console.WriteLine("6. Show average.");
    Console.WriteLine("7. Show highest score.");
    Console.WriteLine("8. Show lowest score.");
    Console.Write("\nYour choice: ");
}

// Extracted validation to avoid repeating the same condition in multiple places
static bool IsValidScore(int score)
{
    return score >= 0 && score <= 100;
}



static string GetGrade(int score)
{
    if (score >= 90) return "A";
    else if (score >= 70) return "B";
    else if (score >= 50) return "C";
    else return "F";
}

static void ShowScores(List<int> scores)
{   
    if (scores.Count == 0)
    {
        Console.WriteLine("No scores available.");
        return;
    }

    foreach( int score in scores)
    {
        Console.WriteLine($"{score} {GetGrade(score)}");
    }
}

// Intentionally using manual loop instead of LINQ to practice fundamentals
//  static void ShowAverage(List<int> scores)
//  {
 //   double average = scores.Average();
//    Console.WriteLine($"Srednia ocen to: {average:F2}");
//   }

static void ShowAverage(List<int> scores)
{   
    if (scores.Count == 0)
    {
        Console.WriteLine("No scores to calculate average.");
        return;
    }
    int sum = 0;
    
    foreach(int score in scores)
    {
    sum += score;
    }
        
    double average = (double)sum / scores.Count;

    Console.WriteLine($"Average score: {average:F2}");
    
}

static void ShowMaxScore(List<int> scores)
{
    
    if (scores.Count == 0)
    {
        Console.WriteLine("No scores available.");
        return;
    }

    int maxScore = scores[0];

    foreach (int score in scores)
    {
        if (score > maxScore) maxScore = score;
    }

    Console.WriteLine($"Highest score: {maxScore}");
}

static void ShowMinScore(List<int> scores)
{
    if (scores.Count == 0)
    {
        Console.WriteLine("No scores available.");
        return;
    }

    int minScore = scores[0];

    foreach (int score in scores)
    {
        if (score < minScore) minScore = score;
    }

    Console.WriteLine($"Lowest score: {minScore}");
}
