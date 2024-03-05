fun main() {
    // Prompting user to input two strings
    println("Enter First Character:")
    var character1 = readLine() ?: ""

    println("Enter Second Character:")
    var character2 = readLine() ?: ""

    // Finding unique characters
    var uniqueChars = ""

    // Loop through character1 to find unique characters
    for (c1 in character1) {
        var found = 0
        for (c2 in character2) {
            if (c1.equals(c2, ignoreCase = true)) {
                found = 1
                break
            }
        }
        if (found == 0 && !uniqueChars.contains(c1, ignoreCase = true) &&
            character1.count { it.equals(c1, ignoreCase = true) } == 1 &&
            character2.count { it.equals(c1, ignoreCase = true) } == 0
        ) {
            uniqueChars += c1
        }
    }

    // Loop through character2 to find unique characters
    for (c2 in character2) {
        if (!character1.contains(c2, ignoreCase = true) &&
            !uniqueChars.contains(c2, ignoreCase = true) &&
            character2.count { it.equals(c2, ignoreCase = true) } == 1
        ) {
            uniqueChars += c2
        }
    }

    // Displaying the result
    if (uniqueChars.isEmpty()) {
        println("No Unique Character")
    } else {
        println("Unique Characters are")
        var index = 1
        for (c in uniqueChars) {
            println("[$index] $c")
            index++
        }
    }
}
