fun main() {
    // Declare variables to store unique characters and their counts for both input strings
    var uniqueChars1 = ""
    var uniqueChars2 = ""

    var uniqueCount1 = 0
    var uniqueCount2 = 0
    var nonUniqueCount1 = 0
    var nonUniqueCount2 = 0

    // Prompt the user to enter the first character string
    println("Enter First Character:")
    val character1 = readLine() ?: "" // Read user input for the first character string, if empty use an empty string

    // Prompt the user to enter the second character string
    println("Enter Second Character:")
    val character2 = readLine() ?: "" // Read user input for the second character string, if empty use an empty string

    // Find unique characters for the first character
    for (i in character1.indices) { // Iterate through each index of the first character string
        val currentChar = character1[i] // Get the current character at the current index
        var found = false // Initialize a variable to track if a duplicate is found

        // Check for duplicates within the first character string
        for (j in character1.indices) { // Iterate through each index of the first character string again for comparison
            if (i != j && character1[j].equals(currentChar, ignoreCase = true) && currentChar != ' ') { // Check if the characters are equal (ignoring case) and not comparing the same character
                found = true // If a duplicate is found, set the found flag to true
                nonUniqueCount1++ // Increment the count of non-unique characters
                break // Exit the loop as a duplicate is found
            }
        }

        // If the character is not a duplicate and not already present, add it to uniqueChars1
        if (!found && !uniqueChars1.contains(currentChar, ignoreCase = true)) { // Check if the character is not a duplicate and not already present in uniqueChars1
            uniqueChars1 += currentChar + " " // Add the character to uniqueChars1
            uniqueCount1++ // Increment the count of unique characters
        }
    }
    // Trim the uniqueChars1 string to remove any leading or trailing whitespace
    uniqueChars1 = uniqueChars1.trim()

    // Find unique characters for the second character
    for (i in character2.indices) { // Iterate through each index of the second character string
        val currentChar = character2[i] // Get the current character at the current index
        var found = false // Initialize a variable to track if a duplicate is found

        // Check for duplicates within the second character string
        for (j in character2.indices) { // Iterate through each index of the second character string again for comparison
            if (i != j && character2[j].equals(currentChar, ignoreCase = true) && currentChar != ' ') { // Check if the characters are equal (ignoring case) and not comparing the same character
                found = true // If a duplicate is found, set the found flag to true
                nonUniqueCount2++ // Increment the count of non-unique characters
                break // Exit the loop as a duplicate is found
            }
        }

        // If the character is not a duplicate and not already present, add it to uniqueChars2
        if (!found && !uniqueChars2.contains(currentChar, ignoreCase = true)) { // Check if the character is not a duplicate and not already present in uniqueChars2
            uniqueChars2 += currentChar + " " // Add the character to uniqueChars2
            uniqueCount2++ // Increment the count of unique characters
        }
    }
    // Trim the uniqueChars2 string to remove any leading or trailing whitespace
    uniqueChars2 = uniqueChars2.trim()

    // Check if both input strings are the same
    if (character1.equals(character2, ignoreCase = true)) { // Check if both input strings are equal (ignoring case)
        println("No Unique Characters") // Print a message indicating no unique characters if both input strings are the same
    } else {
        // Print unique characters, the number of unique characters, and the number of non-unique characters for both input strings
        println("Unique First Character is: $uniqueChars1")
        println("Number of Unique Characters in First Character: $uniqueCount1")
        println("Number of Non-Unique Characters in First Character: $nonUniqueCount1")
        println("Unique Second Character is: $uniqueChars2")
        println("Number of Unique Characters in Second Character: $uniqueCount2")
        println("Number of Non-Unique Characters in Second Character: $nonUniqueCount2")

        // Combine unique characters from both input strings
        var combinedUniqueChars = "" // Initialize a string to store combined unique characters
        for (char in uniqueChars1 + uniqueChars2) { // Iterate through each character in the combined unique characters string
            if (!combinedUniqueChars.contains(char, ignoreCase = true)) { // Check if the character is not already present in combinedUniqueChars
                combinedUniqueChars += char // Add the character to combinedUniqueChars
            }
        }

        // If there are no unique characters in the combined set, print "No More Unique Characters"
        if (combinedUniqueChars.isEmpty()) { // Check if the combined unique characters string is empty
            println("No More Unique Characters") // Print a message indicating no more unique characters
        } else {
            // Print the combined set of unique characters
            println("Combined Unique Character is: $combinedUniqueChars")
        }
    }
}
