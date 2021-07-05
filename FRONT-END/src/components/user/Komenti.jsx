import React, { useState, useEffect } from 'react';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Button from '@material-ui/core/Button';
import axios from 'axios'
import { Header, Icon, Modal,Input } from 'semantic-ui-react'
import 'semantic-ui-css/semantic.min.css'
import  SearchBar  from './navbar/SearchBar';
import {BoxContainer,Flexirimi} from './navbar/StyledComponents';


export  function KomentiTable() {

    const token = window.localStorage.getItem('token');
    const [data, setData] = useState('')
    const config = {
        headers: {
            Authorization: 'Bearer ' + token}
        };

    const[komenti,setKomenti] = useState([]);

    const [modali, setModal] = useState({
        modal:{
            currentID:0,
            open:false,
        }
    });

    const [Editmodal, setEditModal] = useState({
        modali:{
            currentID:0,
            open:false,
            titulli:'',
            body:''
        }
    });
    const [AddModal, setAddModal] = useState({
        modal:{
            titulli:'',
            body:'',
            open:false,
        }
    });
    const[SearchField,setSearchField]=useState('');

    useEffect(() => {
        axios.get('http://localhost:5000/api/Komenti',config).then(response => {
            setKomenti(response.data)
            console.log(response.data);
        });

    }, [komenti])

    const fshijKomentin = async () => {

        setModal({open:false})

        axios.delete("http://localhost:5000/api/Komenti/" + modali.currentID,config)
            .then((response) => {
                console.log(response.data)
            })
            .catch((error) => {
                console.log(error);
            })

    }
    
    function handleChange(e){
        setData(e.target.value);
        console.log(data);
    }
    
    const UpdateKomenti = async () => {
        console.log(Editmodal.currentID);
        console.log(data);

        setEditModal({open:false})
        axios.put("http://localhost:5000/api/Koment/" + Editmodal.currentID, 
        {komentiId:Editmodal.currentID,titulli:data[0],komenti:data[1]},config)
            .then((response) => {
                console.log(response.data)
            })
            .catch((error) => {
                console.log(error.data);
            })

    }

    const ShtoKoment = async () => {
    
        setAddModal({open:false})
        axios.post("http://localhost:5000/api/Koment", {titulli:data[0],body:data[1]})
            .then((response) => {
                console.log(response.data.message)
            })
            .catch((error) => {
                console.log(error.data);
            })

    }


    // const classes = useStyles();

    return (
        <BoxContainer>
            <div style={{margin:30,padding:0 , width:500}}>
            <Flexirimi>
            <div style={{display:'block', padding:10, marginBottom:1}}>
            <SearchBar placeholder="Enter Name" handleChange={e=>setSearchField(e.target.value)} />
            </div>
            <div style={{display:'block', padding:10}}>
            <Button  className="butoni" variant="contained" color="secondary"
            onClick={() => setAddModal({open:true})}>
            Shto nje Koment
            </Button>
            </div>
            </Flexirimi>
            </div>
            <Table className="" aria-label="simple table">
                <TableHead>
                    <TableRow>
                        <TableCell>Komenti ID</TableCell>
                        <TableCell align="right">Titulli Komentit</TableCell>
                        <TableCell align="right">Komenti</TableCell>
                        <TableCell align="right">Manage</TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                {komenti.filter(rreshti=>rreshti.titulli.toLowerCase()
                .includes(SearchField.toLowerCase())).map((row,key)=>(
                    <TableRow key={row.komentiId}>
                        <TableCell align="right">{row.komentiId}</TableCell>
                        <TableCell align="right">{row.titulli}</TableCell>
                        <TableCell align="right">{row.body}</TableCell>
                        <TableCell align="right"> <Button variant="contained" color="primary" 
                        onClick={() => 
                        setEditModal(
                            {currentID:row.komentiId,open:true,titulli:row.titulli,body:row.body})}>
                            Perditeso
                        </Button>
                            <Button variant="contained" color="secondary"
                            onClick={() => setModal({currentID:row.bodyID,open:true})}>
                                Fshij
                            </Button>
                        </TableCell>
                    
                    </TableRow>
                ))}
                </TableBody>
            </Table>
            
            {/* Modali per Delete */}

            <Modal
                closeIcon
                open={modali.open}
                onClose={() => setModal({open:false})}
                onOpen={() => setModal({open:true})}
            >
                <Header icon='archive' content='Konfirmo Fshierjen!' />
                <Modal.Content>
                    <p>
                    Deshironi te fshini Komentin?
                    </p>
                </Modal.Content>
                <Modal.Actions>
                    <Button color='red' onClick={() => setModal({open:false})}>
                        <Icon name='remove' /> No
                    </Button>                   
                    <Button color='green' onClick={fshijKomentin}>
                        <Icon name='checkmark' /> Yes
                    </Button>
                </Modal.Actions>
            </Modal>

            {/* Modali per Edit */}
            
            <Modal
                closeIcon
                open={Editmodal.open}
                onClose={() => setEditModal({open:false})}
                onOpen={() => setEditModal({open:true})}
            >
                <Header icon='archive' content='Edito Te Dhenat!' />
                <Modal.Content>
                <Input focus placeholder='Search...' defaultValue={Editmodal.titulli} 
                onChange={handleChange} />
                <Input focus placeholder='Search...' defaultValue={Editmodal.body} 
                onChange={handleChange} />
                </Modal.Content>
                <Modal.Actions>
                    <Button color='red' onClick={() => setEditModal({open:false})}>
                        <Icon name='remove' /> Pishmon
                    </Button>
                    <Button color='green' onClick={UpdateKomenti}>
                        <Icon name='checkmark' /> Perditeso
                    </Button>
                </Modal.Actions>
            </Modal>

               {/* Modali per Add */}
            <Modal
                closeIcon
                open={AddModal.open}
                onClose={() => setAddModal({open:false})}
                onOpen={() => setAddModal({open:true})}
            >
                <Header icon='archive' content='Shto Koment!' />
                <Modal.Content>
                <Input focus placeholder='Titulli Komentit' 
                onChange={handleChange} />
                <Input focus placeholder='body' 
                onChange={handleChange} />
                </Modal.Content>
                <Modal.Actions>
                    <Button color='red' onClick={() => setAddModal({open:false})}>
                        <Icon name='remove' /> Pishmon
                    </Button>
                    <Button color='green' onClick={ShtoKoment}>
                        <Icon name='checkmark' /> Shto
                    </Button>
                </Modal.Actions>
            </Modal>
        </BoxContainer>
    );
}