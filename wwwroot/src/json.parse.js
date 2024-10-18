
/**
 * Tries to transform a string into a JSON object.
 * @param {string} text - The string to be converted.
 * @returns {object | boolean} Either returs the JSON object, or a boolean indicating it is not a parsable string.
 */
function tryParseJson (text)
{
    try
    {
        return JSON.parse(text);
    }
    catch(ex)
    {
        return false;
    }
}

export default tryParseJson;

