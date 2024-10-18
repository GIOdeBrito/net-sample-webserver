
/**
 * HTTP request type enum.
 * @type {object}
 * @property {string} get - The GET HTTP request.
 * @property {string} post - The POST HTTP request.
 */
const RequestMethod = Object.freeze({ post: "POST", get: "GET" });

/**
 * A simple HTTP requester.
 * @param {string} url - The request url.
 * @param {object} reqobj - The JSON object to be sent to the server.
 * @returns {Promise<object>} Returns the object with the status and response text.
 */
function httpreq (url, reqobj = { })
{
    let type = RequestMethod.get;
    
    const xmlrequest = new XMLHttpRequest();

    if(Object.keys(reqobj).length > 0)
    {
        type = RequestMethod.post;
    }
    
    xmlrequest.open(type, url, true);
    xmlrequest.setRequestHeader("Content-Type", "application/json");
    xmlrequest.send(JSON.stringify(reqobj));

    return new Promise(resolve =>
    {
        xmlrequest.onload = (res) =>
        {
            resolve({
                "status": res.target.status,
                "response": res.target.responseText,
                "raw": res
            });
        };
    });
}

export default httpreq;

