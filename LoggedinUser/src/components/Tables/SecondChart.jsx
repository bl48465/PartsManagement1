import React, { useEffect, useState } from 'react';
import { Bar, Pie, Doughnut } from 'react-chartjs-2'
import axios from 'axios';

function SecondChart() {
    const [dataa, setData] = useState([]);

    useEffect(() => {
        axios
            .get("http://dummy.restapiexample.com/api/v1/employees")
            .then((response)=>{
            setData(response.data.data);
            console.log(dataa[0].employee_name)
            
            })

            }, []);

        return (
            <div className="App">
                <h1>Welcome to ChartJS Demo</h1>
                <Bar
                    data={{
                        labels: [dataa[0].employee_name,dataa[1].employee_name,dataa[2].employee_name],
                        datasets: [{
                            label: 'Store 1',
                            data: [dataa[0].employee_salary,dataa[0].employee_salary,dataa[0].employee_salary],
                            backgroundColor: 'red',
                            barThickness: 12
                        }
                    
                        ]
                    }}
                >
                </Bar>



            </div>
        );
    }

export default SecondChart;