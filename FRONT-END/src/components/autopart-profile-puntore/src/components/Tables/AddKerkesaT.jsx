import React, { useState } from 'react';
import Button from '@material-ui/core/Button';
import axios from 'axios';
import { Header, Icon, Modal, Input } from 'semantic-ui-react';
import 'semantic-ui-css/semantic.min.css';
import { BoxContainer,Flexirimi,ButtonContainer } from '../StyledComponents'; 


export default function AddKerkesaTable() {
    const [emrimbiemri, setEmriMbiemri] = useState("");
    const [email, setEmail] = useState("");
    const [marka, setMarka] = useState("");
    const [modeli, setModeli] = useState("");
    const [mbishkrimi, setMbishkrimi] = useState("");


    const [AddModal, setAddModal] = useState({
        modali: {
            open: false,

        }
    })


    const ShtoKerkesa = async () => {

        setAddModal({ open: false })
        axios.post("http://localhost:5000/api/Kerkesa", { emrimbiemri, email, marka, modeli, mbishkrimi }, { withCredentials: true })
            .then((response) => {
                console.log(response.data.message)
            })
            .catch((error) => {
                console.log(error.data);
            })
    }

    return (
        <BoxContainer>
            <Flexirimi>
                <Button className="butoni" variant="contained" color="secondary"
                    onClick={() => setAddModal({ open: true })}>
                    Request Model
                </Button>
                </Flexirimi>

            <Modal closeIcon open={AddModal.open} onClose={() => setAddModal({ open: false })} onOpen={() => setAddModal({ open: true })}>
                <Header icon="archive" content="Shto Kerkes!" />
                <Modal.Content>
                    <Input className='hapesira20em' focus placeholder="Emri Mbiemri"
                        onChange={(e) => setEmriMbiemri(e.target.value)} name="emrimbiemri" value={emrimbiemri} /><br></br>

                    <Input className='hapesira20em' focus placeholder="Email"
                        onChange={(e) => setEmail(e.target.value)} name="email" /><br></br>

                    <Input className='hapesira20em' focus placeholder="Marka"
                        onChange={(e) => setMarka(e.target.value)} name="marka" /><br></br>

                    <Input className='hapesira20em' focus placeholder="Modeli"
                        onChange={(e) => setModeli(e.target.value)} name="modeli" /><br></br>

                    <Input className='hapesira20em' focus placeholder="Mbishkrimi"
                        onChange={(e) => setMbishkrimi(e.target.value)} name="mbishkrimi" />
                </Modal.Content>

                <Modal.Actions>
                    <Button color="red" onClick={() => setAddModal({ open: false })}>
                        <Icon name='remove' />Anulo
                    </Button>
                    <Button color="green" onClick={ShtoKerkesa}>
                        <Icon name="checkmark" />Request
                    </Button>
                </Modal.Actions>
            </Modal>


        </BoxContainer>
    );

}










