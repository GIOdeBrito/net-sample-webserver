
import httpreq from "./httpreq.js";
import tryParseJson from "./json.parse.js";

window.addEventListener('load', function ()
{
    controls();
});

function controls ()
{
    window['btime'].onclick = () => timeRequest();
    window['buser'].onclick = () => setUser();
}

async function timeRequest ()
{
    let request = await httpreq("/api/v1/time");
    let json = tryParseJson(request.response);

    window['result'].innerText = 'Current time: ' + json.result;
}

async function setUser ()
{
    let name = String(window.prompt("Inform name"));
    let age = Number(window.prompt("Inform age"));

    const obj = {
        name: name,
        age: age
    };

    let request = await httpreq("/api/v2/setuser", obj);

    if(request.status === 200)
    {
        window.location.reload();
        return;
    }

    console.error(request.response);
}


