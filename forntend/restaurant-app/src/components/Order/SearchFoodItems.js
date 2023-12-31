import React,{useState,useEffect} from 'react'
import { ENDPOINTS, createAPIEndpoint } from '../../api'
import { List,ListItem,ListItemText,Paper,IconButton, InputBase,makeStyles, ListItemSecondaryAction } from '@material-ui/core';
import SearchTowToneIcon from '@material-ui/icons/SearchTwoTone'
import PlusOneIcon from '@material-ui/icons/PlusOne';
import ArrowforwardIosIcon from '@material-ui/icons/ArrowForwardIos';

const useStyles = makeStyles(theme=>({
    searchPaper:{
        padding:'2px 4px',
        display:'flex',
        alignItems:'center'
    },

    searchInput:{
        marginLeft:theme.spacing(1.5),
        flex:1
    },

    listRoot:{
        marginTop:theme.spacing(1),
        maxHeight:450,
        overflow:'auto',
        '& li:hover':{
            cursor:'pointer',
            backgroudColor:'#E3E3E3'
        },
        '& ;li:hover .MuiButtonBase-root':{
            display:'block',
            color:'#000',
        },
        '& .MuiButtonBase-root:hover':{
            backgroudColor:'transparent'
        }
    }
}))


export default function SearchFoodItems(props) {
 
    const { values,setValues }=props;

    let orderedFoodItems = values.orderDetails;

    const [foodItems,setFoodItems]=useState([]);
    const [searchList, setSearchList] = useState([]);
    const [searchKey,setSearchKey] = useState('');
    const classes = useStyles();

    useEffect(()=>{
        createAPIEndpoint(ENDPOINTS.FOODITEM).fetchAll()
        .then(res=>{
            setFoodItems(res.data);
            setSearchList(res.data)
        })
        .catch(err=>console.log(err));
    },[])



    useEffect(()=>{
        let x= [...foodItems];
        x=x.filter(y=>{
            return y.foodItemName.toLowerCase().includes(searchKey.toLowerCase())
            && orderedFoodItems.every(item => item.foodItemId!=y.foodItemId)
        });
        setSearchList(x);
    },[searchKey,orderedFoodItems])


    const addFoodItem = foodItem =>{
        let x={
          orderMasterId:values.orderMasterId,
          orderDetailsId:0,
          foodItemId:foodItem.foodItemId,
          quantity:1,
          foodItemPrice:foodItem.price,
          foodItemName:foodItem.foodItemName    
        }
        setValues({
          ...values,
          orderDetails:[...values.orderDetails,x]
        })
      }
      

  return (
    <>
    <Paper className={classes.searchPaper}>
        <InputBase 
            className={classes.searchInput}
            value={searchKey}
            onChange={e=>setSearchKey(e.target.value)}
            placeholder ="Search food items" />
            <IconButton>
                <SearchTowToneIcon />
            </IconButton>
    </Paper>
    <List className={classes.listRoot}>
        {
            searchList.map((item,index)=>(
                <ListItem
                    key={index}
                    onClick={e=>addFoodItem(item)}>
                        <ListItemText 
                            primary={item.foodItemName}  
                            secondary = {'$'+item.price} />
                            <ListItemSecondaryAction>
                                <IconButton onClick={e=>addFoodItem(item)}>
                                    <PlusOneIcon />
                                    <ArrowforwardIosIcon />
                                </IconButton>
                            </ListItemSecondaryAction>
                        </ListItem>
            ))
        }
    </List>
    </>
  )
}
