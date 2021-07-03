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
import SearchBar from '../SearchBar';
import {BoxContainer,Flexirimi} from '../StyledComponents';



export default function KomentiTable() {
    const [data, setData] = useState({
        dataInfo:{
            titulliKomentit:'',
            mesazhi:''
        }
    });
    const[komentii,setKomenti] = useState([]);
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
            titulliKomentit:'',
            mesazhi:''
        }
    });
    const [AddModal, setAddModal] = useState({
        modal:{
            titulliKomentit:'',
            mesazhi:'',
            open:false,
        }
    });
    const[SearchField,setSearchField]=useState('');




    useEffect(() => {
        axios.get('http://localhost:5000/api/Koment',{ withCredentials: true }).then(response => {
            console.log(response);
            setKomenti(response.data);
        });

    }, [komentii])

    const fshijKomentin = async () => {

        setModal({open:false})
        axios.delete("http://localhost:5000/api/Koment/" + modali.currentID, { withCredentials: true })
            .then((response) => {
                console.log(response.data.message)
            })
            .catch((error) => {
                console.log(error.data);
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
        {komentiID:Editmodal.currentID,titulli:data[0],komenti:data[1]}, { withCredentials: true })
            .then((response) => {
                console.log(response.data.message)
            })
            .catch((error) => {
                console.log(error.data);
            })

    }

    const ShtoKoment = async () => {
     
        setAddModal({open:false})
        axios.post("http://localhost:5000/api/Koment/1", {titulli:data[0],mesazhi:data[1]}, { withCredentials: true })
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
                {komentii.filter(rreshti=>rreshti.emriFurnitorit.toLowerCase()
                .includes(SearchField.toLowerCase())).map((row,key)=>(
                    <TableRow key={row.komentiID}>
                        <TableCell align="right">{row.komentiID}</TableCell>
                        <TableCell align="right">{row.titulli}</TableCell>
                        <TableCell align="right">{row.mesazhi}</TableCell>
                        <TableCell align="right"> <Button variant="contained" color="primary" 
                        onClick={() => 
                        setEditModal(
                            {currentID:row.komentiID,open:true,titulliKomentit:row.titulli,mesazhi:row.mesazhi})}>
                            Perditeso
                        </Button>
                            <Button variant="contained" color="secondary"
                            onClick={() => setModal({currentID:row.mesazhiID,open:true})}>
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
                <Input focus placeholder='Search...' defaultValue={Editmodal.titulliKomentit} 
                onChange={handleChange} />
                <Input focus placeholder='Search...' defaultValue={Editmodal.mesazhi} 
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
                <Input focus placeholder='Mesazhi' 
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