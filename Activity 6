fun main() {
    println("Enter First Character:")
    val input1 = readLine() ?: ""

    println("Enter Second Character:")
    val input2 = readLine() ?: ""

    var uniqueChars = ""

    for (char1 in input1) {
        var found = 0
        for (char2 in input2) {
            if (char1.equals(char2, ignoreCase = true)) {
                found = 1
                break
            }
        }
        if (found == 0 && !uniqueChars.contains(char1, ignoreCase = true)) {
            uniqueChars += char1
        }
    }

    for (char2 in input2) {
        if (!input1.contains(char2, ignoreCase = true) && !uniqueChars.contains(char2, ignoreCase = true)) {
            uniqueChars += char2
        }
    }

    if (uniqueChars.isEmpty()) {
        println("No Unique Character")
    } else {
        println("Unique Characters are")
        var index = 1
        for (char in uniqueChars) {
            println("[$index] $char")
            index++
        }
    }
}
