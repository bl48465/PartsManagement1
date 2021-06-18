import axios from 'axios'
import React, { useState} from "react";
import { useEffect } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import FormHelperText from '@material-ui/core/FormHelperText';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';


function DropDownCities() {
    const [loading, setLoading] = useState(true);
    const [qytetet, setQytetet] = useState([]);
    const[value,setValue] = useState();

    useEffect(() => {
        fetch('http://localhost:44395/api/Vendbanimi')
            .then((res) => res.json())
            .then((data) => {
            setQytetet(data);
            })
            .catch((err) => {
            console.log(err);
            });
        }, []);
    return (
        <Select >
        {qytetet.filter((item) => (
            <MenuItem key={item.id} value={item.emriQytetit}>{item.emriQytetit}</MenuItem>
        ))}
        </Select>
    );
}
export default DropDownCities;