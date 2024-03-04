fun main() {
    println("Enter First Character:")
    var character1 = readLine() ?: ""

    println("Enter Second Character:")
    var character2 = readLine() ?: ""

    var uniqueChars = ""

    for (c1 in character1) {
        var found = 0
        for (c2 in character2) {
            if (c1.equals(c2, ignoreCase = true)) {
                found = 1
                break
            }
        }
        if (found == 0 && !uniqueChars.contains(c1, ignoreCase = true)) {
            uniqueChars += c1
        }
    }

    for (c2 in character2) {
        if (!character1.contains(c2, ignoreCase = true) && !uniqueChars.contains(c2, ignoreCase = true)) {
            uniqueChars += c2
        }
    }

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
