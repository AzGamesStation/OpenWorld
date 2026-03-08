using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FizzBuzz : MonoBehaviour
{

    int FizzbuzzFunc(int num)
    {
        if (num % 3 == 0)
        {
            print("fizz");
        }
        else if (num % 5 == 0)
        {
            print("buzz");
        }
        else if (num % 3 == 0 && num % 5 == 0)
        {
            print("fizzbuzz");
        }
        else
        {
            print("");
        }
        return num;
    }

    void isFlaskEmpty(Color[] flask)
    {
        /*
        Takes a Flask (represented as Array of colors) and returns
        if flask is empty i.e. there is no color inside that
        */

        // WRITE YOUR CODE HERE
        for (int i = 0; i < flask.Length; i++)
        {
            if (flask[i] == null)
            {
                print("there is no color inside that");
            }
        }

    }

    void isFlaskFilled(Color[] flask)
    {
        /*
        Takes a Flask (represented as Array of colors) and returns
        if flask is filled i.e. it holds 4 colors
        */

        // WRITE YOUR CODE HERE
        for (int i = 0; i < flask.Length; i++)
        {
            if (flask.Length > 0)
            {
                print("flask is filled");
            }
        }
    }

    void getTopColor(Color[] flask)
    {
        /*
        Takes a Flask (represented as Array of Color (string) and returns
        color that is at top. If flask is empty return null

        Hint: You can get length of flask by using `.length` i.e. `flask.length`
        */

        // WRITE YOUR CODE HERE

        for (int i = 0; i < flask.Length; i++)
        {
            if (i == flask.Length - 1)
            {
                print(flask[i]);
            }
        }

        if (flask.Length == 0)
        {
            return;
        }
    }

    int counter;
    Color topColor;
    void getTopColorOccurances(Color[] flask)
    {
        /*
        Takes a Flask (represented as Array of colors) and returns
        number of occurances of top color. Return 0 if flask is empty

        Hint: You have to loop over flask and count until color isn't what
        is top color. Something like this:

        topColor = <top-flask-color>
        counter = 0
        reverse loop over each color in flask (i.e. last element will come first):
          if topColor == color:
            counter += 1
          else:
            break

        return counter
        */

        // WRITE YOUR CODE HERE

        for (int i = 0; i < flask.Length; i++)
        {
            counter++;
            if (flask[i] == topColor)
            {
                print("counter : " + counter);
                return;
            }
        }
    }

    int colorCounter;
    void isFlaskContainSameColor(Color[] flask)
    {
        /*
        Takes a Flask (represented as Array of colors) and returns
        if all the colors in flask are same. Return false if flask is empty
        */

        // WRITE YOUR CODE HERE

        for (int i = 0; i < flask.Length; i++)
        {
            for (int j = flask.Length; j > 0; j--)
            {
                if (flask[i] == flask[j])
                {
                    colorCounter++;
                }

            }
        }
        if (colorCounter == flask.Length)
        {
            print("All color are same");
        }
        else if (colorCounter == 0)
        {
            print("Flask is Empty");
        }
    }

    void isFlaskFilledWithSameColor(Color[] flask)
    {
        /*
        Takes a Flask (represented as Array of colors) and returns
        if
          - all the colors in flask are same
          - length of flask is 4

        Hint: Use isFlaskContainSameColor and check length is 4
        */

        // WRITE YOUR CODE HERE
        for (int i = 0; i < flask.Length; i++)
        {
            for (int j = flask.Length; j > 0; j--)
            {
                if (flask[i] == flask[j])
                {
                    colorCounter++;
                }

            }
        }
        if (colorCounter == 4)
        {
            print("All color are same");
        }
    }

    bool canPour(Color flaskA, Color flaskB)
    {
        /*
        Takes two flasks (represented as Array of colors) i.e., flaskA and flaskB
        and return true if following rules hold:

        - Flask A is not empty
        - Flask B is not filled
        - Either Flask B is empty or top color on both flasks is same

        Hint: Use above helper functions
        */

        // WRITE YOUR CODE HERE

        if (flaskA != null && flaskB == flaskA)
        {
            return true;
        }
        return false;
    }

    /* DO NOT EDIT ANYTHING BELOW THIS LINE */
}
