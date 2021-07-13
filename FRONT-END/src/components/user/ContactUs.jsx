import React, { useState, useEffect } from 'react';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableRow from '@material-ui/core/TableRow';
import axios from 'axios'
import { Header, Icon, Modal, Input, Button } from 'semantic-ui-react'
import 'semantic-ui-css/semantic.min.css'
import { BoxContainer, Flexirimi, MainDiv, TableHead, TableText, RowText } from './navbar/StyledComponents';
import { DeleteButton } from '../button/delButton';
import { IconContext } from 'react-icons';
import { SearchBar } from './navbar/SearchBar';
import Alert from '@material-ui/lab/Alert';
import { RiQuestionnaireFill } from 'react-icons/ri';
import { selectUser } from '../../reducers/rootReducer'
import { useSelector } from "react-redux";
import Navbar from './navbar/Navbar';
import AdminNav from './adminnav/Navbar';


export function ContactTable() {

    const useri = useSelector(selectUser);

    const config = {
        headers: {
            Authorization: 'Bearer ' + useri.token
        }
    };

    const [alert, setAlert] = useState({
        validity: null,
        message: ''
    })

    const [forma, setForma] = useState([]);

    const [modali, setModal] = useState({
        modal: {
            currentID: 0,
            open: false,
        }
    });

    const removeContactUs = async () => {

        setModal({ open: false })
        axios.delete("http://localhost:5000/api/Contact/" + modali.currentID, config)
            .then((response) => {
                setAlert({ validity: true, message: response.data })
            })
            .catch((error) => {
                setAlert({ validity: false, message: 'Diqka shkoi gabim!' })
            })

    }


    const [SearchField, setSearchField] = useState('');

    useEffect(() => {
        axios.get('http://localhost:5000/api/Contact', config).then(response => {
            setForma(response.data);
        });

    }, [forma])


    return (
        <IconContext.Provider value={{ color: 'white', size: '2%' }}>
            {(useri.roli == "Admin") ? <AdminNav /> : <Navbar />}
            <BoxContainer>
                <MainDiv>
                    <Flexirimi>
                        {(alert.validity == null) ? null : (alert.validity === false) ? <Alert severity="error">{alert.message}</Alert> : <Alert severity="success">{alert.message}</Alert>}
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
                            <TableCell fontSize="large" align="center"><TableText>Emri</TableText></TableCell>
                            <TableCell fontSize="large" align="center"><TableText>Mbiemri</TableText></TableCell>
                            <TableCell fontSize="large" align="center"><TableText>Mesazhi</TableText></TableCell>
                            <TableCell fontSize="large" align="center"><TableText>Email</TableText></TableCell>
                            <TableCell fontSize="large" align="center"><TableText>Data</TableText></TableCell>

                            <TableCell align="right"></TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                    {forma.filter(rreshti => rreshti.emri.toLowerCase()
                            .includes(SearchField.toLowerCase())).map((row, key) => 
                            <TableRow key={row.contactId}>
                                <TableCell align="left"><RiQuestionnaireFill color="#fc4747" size="30" /></TableCell>
                                <TableCell align="center"><RowText>{row.emri}</RowText></TableCell>
                                <TableCell align="center"><RowText>{row.mbiemri}</RowText></TableCell>
                                <TableCell align="center"><RowText>{row.pyetja}</RowText></TableCell>
                                <TableCell align="center"><RowText>{row.email}</RowText></TableCell>
                                <TableCell align="center"><RowText>{row.createdAt}</RowText></TableCell>
                                <TableCell align="right">
                                    <DeleteButton
                                        onClick={() => setModal({ currentID: row.contactId, open: true })}>
                                        <Icon name='delete' />
                                        Fshij
                                    </DeleteButton>
                                </TableCell>
                            </TableRow>

                        )}
                    </TableBody>
                </Table>


                <Modal
                    closeIcon
                    open={modali.open}
                    size='mini'
                    onClose={() => setModal({ open: false })}
                    onOpen={() => setModal({ open: true })}
                >
                    <Header icon='delete' content='Konfirmo fshirjen?' />
                    <Modal.Content>
                        <p>
                            Dëshironi të fshini mesazhin?
                        </p>
                    </Modal.Content>
                    <Modal.Actions>
                        <Button color='black' onClick={() => setModal({ open: false })}>
                            <Icon name='remove' /> Pishmon?
                        </Button>
                        <Button color='green' onClick={removeContactUs}>
                            <Icon name='checkmark' /> Po
                        </Button>
                    </Modal.Actions>
                </Modal>

            </BoxContainer>
        </IconContext.Provider>
    );
}
