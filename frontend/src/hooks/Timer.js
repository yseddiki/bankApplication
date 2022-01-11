import React from 'react'
import { useState, useEffect } from 'react';

const Timer = ({initialMinute ,initialSecond = 0,reset}) => {
    console.log(initialMinute)
    const [ minutes, setMinutes ] = useState(initialMinute);
    const [seconds, setSeconds ] =  useState(initialSecond);
    useEffect(()=>{
        let myInterval = setInterval(() => {
            if (seconds > 0) {
                setSeconds(seconds - 1);
            }
            if (seconds === 0) {
                if (minutes === 0) {
                    reset()
                    setMinutes(initialMinute)
                    setSeconds(initialSecond)
                } else {
                    setMinutes(minutes - 1);
                    setSeconds(59);
                }
            }
        }, 1000)
        return ()=> {
            clearInterval(myInterval);
        };
    });

    return (
        <div>
             <h1> {minutes}:{seconds < 10 ?  `0${seconds}` : seconds}</h1>
        </div>
    )
}

export default Timer;