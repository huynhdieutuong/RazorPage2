using System.ComponentModel.DataAnnotations;

public class EvenNumber : ValidationAttribute
{
    public EvenNumber() => ErrorMessage = "{0} must even number";

    public override bool IsValid(object value)
    {
        if (value == null) return false;

        int i = int.Parse(value.ToString());
        return i % 2 == 0;
    }
}