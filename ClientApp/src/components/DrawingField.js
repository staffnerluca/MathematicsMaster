import React, { setState, useEffect, useState } from 'react';
import "./drawingField.css"

export function DrawingField(){
    const [points, setPoints] = useState([]);
    const [loaded, setLoaded] = useState(false);

    
    useEffect(() => {
        if(!loaded){
            setPoints(createPoints());
            setLoaded(true);
        }
    })


    function createPoints(){
        //1x1 points for the entire div, reloading if div size changes
        const field = document.getElementById("drawingField");
        alert("The field is" + field)
        const height = field.offsetHeight;
        alert(height);
        const width =  field.offsetWidth;
        alert(width);
        let pointsList = ["bla"];
        for(let i = 0; i < height; i++){
            for(let y = 0; y < width; y++){
                pointsList.push([y, i]);
            }
        }
        alert("the list of points: "+pointsList);
        return pointsList;
    }


    function createDivForPoint(){
        
    }


    function DrawPoint(){

    }

    
    function Erase(){

    }


    function ClearField(){

    }


    return(
        <div id="drawingField">
            <h1>Drawing field</h1>
        </div>
    )
}