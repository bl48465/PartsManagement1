import axios from 'axios'
import React, { useState} from "react";
import { useEffect } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import FormHelperText from '@material-ui/core/FormHelperText';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';


function DropDown() {
    const [loading, setLoading] = useState(true);
    const [shtetet, setShtetet] = useState([]);
    const[value,setValue] = useState();

    useEffect(() => {
        fetch('http://localhost:44395/api/Shteti')
            .then((res) => res.json())
            .then((data) => {
            setShtetet(data);
            })
            .catch((err) => {
            console.log(err);
            });
        }, []);
    return (
        <Select >
        {shtetet.map((item) => (
            <MenuItem key={item.id} value={item.emriShtetit}>{item.emriShtetit}</MenuItem>
        ))}
        </Select>
    );
}
export default DropDown;