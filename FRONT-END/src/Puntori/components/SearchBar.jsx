//import { Input } from 'semantic-ui-react';
import { Search } from "semantic-ui-react";
import React from 'react';

const SearchBar = (props)=>{

    return(
        // <Input type='search'
        // className='search'
        // placeholder={props.placeholder}
        // onChange={props.handleChange}
        // >
       // </Input>
           <Search
           fluid
           icon="search"
           placeholder={props.placeholder}
           onSearchChange={props.handleChange}
         />
    )

}
export default SearchBar;


