import React from "react";
import OrderForm from "./OrderForm";
import useForm from "../../hooks/useForm";
import { Grid } from "@material-ui/core";
import SearchFoodItems from "./SearchFoodItems";
import OrderedFoodItems from "./OrderedFoodItems";

const generateOrderNumber = () =>
  Math.floor(100000 + Math.random() * 900000).toString();
const getFreshModelObject = () => ({
  orderMasterId: 0,
  orderNumber: generateOrderNumber(),
  customerId: 0,
  pMethod: "none",
  gTotal: 0,
  deletedOrderItemIds: "",
  orderDetails: []//,
  // customer: {
  //   "customerId": 0,
  //   "customerName": "string"
  // },
});

export default function Order() {
  const {
    values,
    setValues,
    errors,
    setErrors,
    handleInputChange,
    resetControls,
  } = useForm(getFreshModelObject);





  return (
    <Grid container spacing={2}>
      <Grid item xs={12}>
        <OrderForm {...{
            values,
            setValues,
            errors,
            setErrors,
            handleInputChange,
            resetControls
             }} />
      </Grid>
      <Grid item xs={6}>
        <SearchFoodItems
          {...{ 
            values
            ,setValues
          }}
        />
      </Grid>
      <Grid item xs={6}>
        <OrderedFoodItems 
          {...{
            values
            ,setValues
          }}
        />
      </Grid>
    </Grid>
  );
}
