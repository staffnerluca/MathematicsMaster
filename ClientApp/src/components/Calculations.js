import React, { Component } from 'react';

function CreateTwoRandomNumbers(maxf, maxs, condition = () => true){
    let maxTrys = 100;
    let i = 0;
    while(i > maxTrys){
        let first = Math.floor(Math.random() * maxf);
        let second = Math.floor(Math.random() * maxs);
        if(condition(first, second)){
            return [first, second];
        }
        i++;
    }
}


function CreateMultiplication(){
    let max = 9;
    let min = 1;
    let [first, second] = createTwoRandomNumbers(max, min);
    return(
        <p>{first} * {second} </p>
    )
}

function CreateDivision(){
    let maxf = 100;
    let maxs = 10;
    let [first, second] = createTwoRandomNumbers(maxf, maxs, (x, y) => x % y === 0)
    return(
        <p>{first} : {second}</p>
    )
}

function CreateHundredCalculations(Type){
    let i = 0;
    let out = "";
    while(i < 100){
        out+="<h1>Hallo Luggi</h1>";
        i++;
    }
    return(out);
}


export class CreateCalculationsForPrimarySchool extends Component {


    render() {
        return (
            <div>
                <h1>Calculations</h1>
                {CreateHundredCalculations()}
            </div>
      
        );
    }
}
