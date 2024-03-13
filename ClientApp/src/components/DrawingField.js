import React, { setState, useEffect, useState } from 'react';
import "./drawingField.css"

export function DrawingField(){
    const [points, setPoints] = useState([]);
    const [loaded, setLoaded] = useState(false);

    
    useEffect(() => {
        if(!loaded){
            alert(createPoints())
            setPoints(createPoints());
            setLoaded(true);
        }
    })


    function createPoints(){
        //1x1 points for the entire div, reloading if div size changes
        const field = document.getElementById("drawingField");
        alert("The field is" + field)
        const height = field.getAttribute("height");
        const width =  field.getAttribute("width");
        let pointsList = [];
        for(let i = 0; i < height; i++){
            for(let y = 0; y < width; i++){
                pointsList.push([y, i]);
            }
        }
        return "Dieter"
        return pointsList;
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