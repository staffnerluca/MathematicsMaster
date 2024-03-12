import React, { setState } from 'react';
import "./drawingField.css"

export default function DrawingField(){
    const [points, setPoints] = setState([])

    function createPoints(){
        //1x1 points for the entire div, reloading if div size changes
        const field = document.getElementById("drawingField")
        const height = field.height; 
        const width =  field.width;
    }

    function DrawPoint(){

    }

    
    function Erase(){

    }


    function ClearField(){

    }

    
    return(
        <div id="drawingField">

        </div>
    )
}