import React, { useState, useEffect } from 'react';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableRow from '@material-ui/core/TableRow';
import axios from 'axios'
import { Header, Icon, Modal, Input, Button } from 'semantic-ui-react'
import 'semantic-ui-css/semantic.min.css'
import { BoxContainer, Flexirimi, MainDiv, TableHead, TableText, RowText } from './navbar/StyledComponents';
import { AddButton } from '../button/add'
import { UpdateButton } from '../button/update'
import { DeleteButton } from '../button/delButton'
import { IconContext } from 'react-icons';
import { SearchBar } from './navbar/SearchBar';
import Alert from '@material-ui/lab/Alert';
import { GiCardboardBox } from 'react-icons/gi';
import { Select } from './navbar/StyledComponents'; 

export function ProduktiTable() {

    const token = window.localStorage.getItem('token');

    const config = {
        headers: {
            Authorization: 'Bearer ' + token
        }
    };

    const [formState, setFormState] = useState({
        formValues: {
            emri: '',
            number: '',
            sektoriId:0,
            markaId:0
        }
        });

    const [sektoret,setSektoret]=useState([]);

    const [produkti, setProdukti] = useState([]);

    const [marka,setMarka] = useState([]);

    const [modali, setModal] = useState({
        modal: {
            currentID: 0,
            open: false,
        }
    });

    const [alert,setAlert] = useState({
        validity:null,
        message:''
    })

    const [Editmodal, setEditModal] = useState({
        modali: {
            currentID: 0,
            open: false,
            emri: '',
            number:'',
            sektoriId:0,
            markaId:0
        }
    });
    
    const [AddModal, setAddModal] = useState({
        modal: {
            emri: '',
            open: false
        }
    });
    const [SearchField, setSearchField] = useState('');
    const [emri ,setEmri] = useState("");
    const [number, setNumber] = useState("");
    const [sektoriId, setSektoriId] = useState(0);
    const [markaId, setMarkaId] = useState(0);


    useEffect(() => {
        axios.get('http://localhost:5000/api/Produkti', config).then(response => {
            setProdukti(response.data);
        });

    }, [produkti])

    const fshijProduktin = async () => {

        setModal({ open: false })
        axios.delete("http://localhost:5000/api/Produkti/" + modali.currentID, config)
            .then((response) => {
                setAlert({validity:true,message:response.data})
            })
            .catch((error) => {
                setAlert({validity:false,message:error.response.data})
            })
    }

    const handleChange = ({ target }) => {
        const { formValues } = formState;
        formValues[target.name] = target.value;
        setFormState({ formValues });
        };

    const UpdateProdukti = async () => {

        var id=Editmodal.currentID;
        console.log(Editmodal);
        setEditModal({ open: false })
        axios.put("http://localhost:5000/api/Produkti/"+ id, {
            emri: emri===""? Editmodal.emri:emri,
            number: number ===""? Editmodal.number:number,
            sektoriId: sektoriId ===""? Editmodal.sektoriId:sektoriId,
            markaId: markaId ===""? Editmodal.markaid:markaId,
        } ,config)
            .then((response) => {
                console.log(response.data.message)
                setAlert({validity:true,message:response.data})
            })
            .catch((error) => {
                console.log(error);
                setAlert({validity:false,message:error.response.data})
            })

    }

    const ShtoProdukt = async () => {

        setAddModal({ open: false })
        const { formValues } = formState;
        axios.post("http://localhost:5000/api/Produkti/",formValues,config)
            .then((response) => {
                console.log(response.data)
                setAlert({validity:true,message:response.data})
            })
            .catch((error) => {
                console.log(error);
                setAlert({validity:false,message:error.response.data})
            })
    }

    useEffect(()=>{
        axios.get("http://localhost:5000/api/Sektori/user",config)
        .then((response) => {  
            setSektoret(response.data);
        })
    },[])

    useEffect(()=>{
        axios.get("http://localhost:5000/api/Marka",config)
        .then((response) => {  
            setMarka(response.data);
        })
    },[])

    return (
        <IconContext.Provider value={{ color: 'white', size: '2%' }}>
            <BoxContainer>
                <MainDiv>
                    <Flexirimi>
                        <AddButton onClick={() => setAddModal({ open: true })}>
                            <Icon name='add' />
                            Shto produkt
                        </AddButton>
                        {(alert.validity == null) ? null : (alert.validity == false) ? <Alert severity="error">{alert.message}</Alert> : <Alert severity="success">{alert.message}</Alert>}
                        <div style={{ display: 'block', padding: 10, marginBottom: 1 }}>
                            <SearchBar
                                placeholder="Enter Name"
                                handleChange={e => setSearchField(e.target.value)} />

                        </div>
                    </Flexirimi>
                </MainDiv>

                <Table className="" aria-label="simple table">
                    <TableHead>
                        <TableRow>
                            <TableCell align="left"><TableText></TableText></TableCell>
                            <TableCell fontSize="large" align="center"><TableText>Emri Produktit</TableText></TableCell>
                            <TableCell fontSize="large" align="center"><TableText>Numri</TableText></TableCell>
                            <TableCell fontSize="large" align="center"><TableText>Sasia</TableText></TableCell>
                            <TableCell fontSize="large" align="center"><TableText>Marka</TableText></TableCell>
                            <TableCell fontSize="large" align="center"><TableText>Sektori</TableText></TableCell>
                            <TableCell align="right"><TableText>Menaxho</TableText></TableCell>

                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {produkti.filter(rreshti => rreshti.emri.toLowerCase()
                            .includes(SearchField.toLowerCase())).map((row, key) => (
                                <TableRow key={row.produktiId}>
                                    <TableCell align="left"><GiCardboardBox color="#fc4747" size="30"/></TableCell>
                                    <TableCell align="center"><RowText>{row.emri}</RowText></TableCell>
                                    <TableCell align="center"><RowText>{row.number}</RowText></TableCell>
                                    <TableCell align="center"><RowText>{row.sasia}</RowText></TableCell>
                                    <TableCell align="center"><RowText>{row.marka.emri}</RowText></TableCell>
                                    <TableCell align="center"><RowText>{row.sektori.emri}</RowText></TableCell>
                                    <TableCell align="right">
                                        <UpdateButton
                                            onClick={() =>
                                                setEditModal(
                                                    { currentID: row.produktiId, open: true, emri: row.emri ,number:row.number, sektoriId:row.sektoriId, markaId: row.markaId})}>
                                            <Icon name='history' />
                                            Përditëso
                                        </UpdateButton>
                                        <DeleteButton
                                            onClick={() => setModal({ currentID: row.produktiId,open: true })}>
                                            <Icon name='delete' />
                                            Fshij
                                        </DeleteButton>
                                    </TableCell>
                                </TableRow>
                            ))}
                    </TableBody>
                </Table>

                <Modal
                    closeIcon
                    open={modali.open}
                    size='mini'
                    onClose={() => setModal({ open: false })}
                    onOpen={() => setModal({ open: true })}
                >
                    <Header icon='archive' content='Konfirmo fshirjen e produktit' />
                    <Modal.Content>
                        <p>
                            Dëshironi të fshini Produktin?
                        </p>
                    </Modal.Content>
                    <Modal.Actions>
                        <Button color='black' onClick={() => setModal({ open: false })}>
                            <Icon name='remove' /> Jo
                        </Button>
                        <Button color='green' onClick={fshijProduktin}>
                            <Icon name='checkmark' /> Po
                        </Button>
                    </Modal.Actions>
                </Modal>
                <Modal
                    closeIcon
                    open={Editmodal.open}
                    size='mini'
                    onClose={() => setEditModal({ open: false })}
                    onOpen={() => setEditModal({ open: true })}
                >
                    <Header icon='archive' content='Edito të dhënat' />
                    <Modal.Content>
                    <Input focus placeholder='Emri produktit' name="emri"  required defaultValue={Editmodal.emri}
                            onChange={(e) => setEmri(e.target.value)} />
                        <Input focus placeholder='Numri' name="number" defaultValue={Editmodal.number}
                            onChange={(e) => setNumber(e.target.value)} />

                        <Select   onChange={(e) => setSektoriId(e.target.value)} name="sektoriId" required defaultValue={Editmodal.sektoriId}>   
                            {sektoret.map((e, key) => {  
                            return <option key={key} value={e.sektoriId}>{e.emri}</option>;  
                            })}  
                        </Select>
                        
                        <Select  onChange={(e) => setMarkaId(e.target.value)} required name="markaId" defaultValue={Editmodal.markaId}>   
                            {marka.map((e, key) => {  
                            return <option key={key} value={e.markaId}>{e.emri}</option>;  
                            })}  
                        </Select>
        
                    </Modal.Content>
                    <Modal.Actions>
                        <Button color='black' onClick={() => setEditModal({ open: false })}>
                            <Icon name='remove' />Pishmon
                        </Button>
                        <Button color='green' onClick={UpdateProdukti}> 
                            <Icon name='checkmark' /> Përditëso
                        </Button>
                    </Modal.Actions>
                </Modal>
                <Modal
                    closeIcon
                    open={AddModal.open}
                    size='mini'
                    onClose={() => setAddModal({ open: false })}
                    onOpen={() => setAddModal({ open: true })}
                >
                    <Header icon='add' content='Shto produkt' />
                    <Modal.Content>
                        <Input focus placeholder='Emri produktit' name="emri" 
                            onChange={handleChange} />
                        <Input focus placeholder='Numri' name="number"
                            onChange={handleChange} />

                        <Select  onChange={handleChange} name="sektoriId"  >  
                            <option>Sektori</option> 
                            {sektoret.map((e, key) => {  
                            return <option key={key} value={e.sektoriId}>{e.emri}</option>;  
                            })}  
                        </Select>
                        
                        <Select  onChange={handleChange} name="markaId"  >  
                            <option>Marka</option> 
                            {marka.map((e, key) => {  
                            return <option key={key} value={e.markaId}>{e.emri}</option>;  
                            })}  
                        </Select>
        
                    </Modal.Content>
                    <Modal.Actions>
                        <Button color='black' onClick={() => setAddModal({ open: false })}>
                            <Icon name='remove' /> Pishmon
                        </Button>
                        <Button color='green' onClick={ShtoProdukt}>
                            <Icon name='checkmark' />Shto
                        </Button>
                    </Modal.Actions>
                </Modal>
            </BoxContainer>
        </IconContext.Provider>
    );
}
