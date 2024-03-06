fun main() {
    var uniqueChars1 = ""
    var uniqueChars2 = ""

    var uniqueCount1 = 0
    var uniqueCount2 = 0
    var nonUniqueCount1 = 0
    var nonUniqueCount2 = 0

    println("Enter First Character:")
    val character1 = readLine() ?: ""

    println("Enter Second Character:")
    val character2 = readLine() ?: ""

    for (i in character1.indices) {
        val currentChar = character1[i]
        var found = false

        for (j in character1.indices) {
            if (i != j && character1[j].equals(currentChar, ignoreCase = true) && currentChar != ' ') {
                found = true
                nonUniqueCount1++
                break
            }
        }

        if (!found && !uniqueChars1.contains(currentChar, ignoreCase = true)) {
            uniqueChars1 += currentChar + " "
            uniqueCount1++
        }
    }
    uniqueChars1 = uniqueChars1.trim()

    for (i in character2.indices) {
        val currentChar = character2[i]
        var found = false

        for (j in character2.indices) {
            if (i != j && character2[j].equals(currentChar, ignoreCase = true) && currentChar != ' ') {
                found = true
                nonUniqueCount2++
                break
            }
        }

        if (!found && !uniqueChars2.contains(currentChar, ignoreCase = true)) {
            uniqueChars2 += currentChar + " "
            uniqueCount2++
        }
    }
    uniqueChars2 = uniqueChars2.trim()

    if (character1.equals(character2, ignoreCase = true)) {
        println("No Unique Characters")
    } else {
        println("Unique First Character is: $uniqueChars1")
        println("Number of Unique Characters in First Character: $uniqueCount1")
        println("Number of Non-Unique Characters in First Character: $nonUniqueCount1")
        println("Unique Second Character is: $uniqueChars2")
        println("Number of Unique Characters in Second Character: $uniqueCount2")
        println("Number of Non-Unique Characters in Second Character: $nonUniqueCount2")

        var combinedUniqueChars = ""
        var combinedUniqueCount = 0
        var combinedNonUniqueCount = 0
        for (char in uniqueChars1 + uniqueChars2) {
            if (!uniqueChars1.contains(char, ignoreCase = true) || !uniqueChars2.contains(char, ignoreCase = true)) {
                combinedUniqueChars += char
                combinedUniqueCount++
            } else {
                combinedNonUniqueCount++
            }
        }

        if (combinedUniqueChars.isEmpty()) {
            println("No More Unique Characters")
        } else {
            println("Combined Unique Character is: $combinedUniqueChars")
            println("Number of Combined Unique Characters: $combinedUniqueCount")
            println("Number of Combined Non-Unique Characters: $combinedNonUniqueCount")
        }
    }
}
