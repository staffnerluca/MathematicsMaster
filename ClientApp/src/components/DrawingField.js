import React, { setState, useEffect, useState } from 'react';
import "./drawingField.css"

export function DrawingField(){
    //key: point id; value: color
    const [pointsWithColor, setPointsWithColor] = useState({});
    const [loaded, setLoaded] = useState(false);
    const [backgroundColor, setBackgroundColor] = useState("black")

    useEffect(() => {
        if(!loaded){
            setPointsWithColor(createPoints());
            setLoaded(true);
        }
    })


    function createPoints(){
        const field = document.getElementById("drawingField");
        const height = field.offsetHeight;
        const width =  field.offsetWidth;
        
        let tempPointsWithColor = {};
        for(let i = 0; i < height*width; i++){
            tempPointsWithColor[i] = backgroundColor;
        }
        setPointsWithColor(tempPointsWithColor);
    }


    function DrawPoint(){
        return(
            <div>
                {Object.keys(pointsWithColor).map((pointID) => (
                    <div cid={'dfP'+ pointID.toString()} lassName='dfPoint' height='1px' width='1px' backgroundColor={pointsWithColor[pointID]}></div>
                ))}
            </div>
        )
    }

    
    function Erase(){

    }


    function ClearField(){
        for(let i = 0; i < Object.keys(pointsWithColor).length(); i++){
            pointsWithColor[i] = backgroundColor;
        }
        alert("Erased the drawing");
    }


    return(
        <div id="drawingField" height='400px' width='200px'>
            <h1>Drawing field</h1>
            <DrawingField />
        </div>
    )
}