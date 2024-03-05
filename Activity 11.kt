fun main() {
    // Prompt the user to enter a percentage
    println("Enter a percentage:")

    // Read the input from the user and convert it to a Double
    val percentage = readLine()!!.toDouble() / 100 // Convert percentage to decimal

    // Prompt the user to enter a value for which the percentage should be calculated
    println("Enter a value to get a percentage:")

    // Read the input from the user and convert it to a Double
    val value = readLine()!!.toDouble()

    // Calculate the percentage of the value
    val result = percentage * value

    // Print a message indicating that the answer is about to be displayed
    println("Answer:")

    // Print the result with 5 decimal places
    println("%.5f".format(result))
}
