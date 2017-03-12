
var finished : boolean = false;


function OnTriggerEnter()
{
    finished = true;
}


function OnGUI()
{
    if(finished){
       
        GUI.Label (Rect(500, 500, 400, 80), "DONE");
    }

       
}