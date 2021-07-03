import React from 'react';
import './Form.css';

export default class Form extends React.Component{
    state = {
        produktID: '',
        sasia: '',
        cmimi: ''

    }


    render () {
        return(
                <form>
                    <div className='form-content'>
                        <label className='form-label'>ProduktID: </label>
                        <input className={'input'} placeholder='ProduktiID'
                        value={this.state.produktID}
                        onChange={e => this.setState({produktID:e.target.value})} /> 

                        <label className='form-label'>Sasia: </label>
                        <input className={'input'} placeholder='Sasia'
                        value={this.state.sasia}
                        onChange={e => this.setState({sasia:e.target.value})} /> 

                        <label className='form-label'>Çmimi: </label>
                        <input className={'input'} placeholder='Çmimi'
                        value={this.state.cmimi}
                        onChange={e => this.setState({cmimi:e.target.value})} /> 
                        <button className='form-btn'>Shto</button>
                    </div>
                </form>
          
        );
    }

}