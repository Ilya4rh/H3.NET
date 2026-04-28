namespace H3Net.Enums;

internal enum Direction
{
    // H3 digit in center 
    CenterDigit = 0,
    // H3 digit in k-axes direction 
    KAxesDigit = 1,
    // H3 digit in j-axes direction 
    JAxesDigit = 2,
    // H3 digit in j == k direction 
    JkAxesDigit = 3,
    // H3 digit in i-axes direction 
    AxesDigit = 4,
    // H3 digit in i == k direction 
    IkAxesDigit = 5,
    // H3 digit in i == j direction 
    IjAxesDigit = 6,
    // H3 digit in the invalid direction 
    InvalidDigit = 7,
    
    // Child digit which is skipped for pentagons 
    PentagonSkippedDigit = KAxesDigit
}