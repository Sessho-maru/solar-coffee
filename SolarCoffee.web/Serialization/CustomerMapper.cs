using System;

namespace SolarCoffee.web.Serialization
{
    public static class CustomerMapper
    {
        public static web.ViewModels.CustomerModel CustomerDataToCustomerView(data.models.Customer customer)
        {
            return new web.ViewModels.CustomerModel {
                id = customer.id,
                createdOn = customer.createdOn,
                updatedOn = customer.updatedOn,
                firstName = customer.firstName,
                lastName = customer.lastName,
                primaryAddress = AddressDataToAddressView(customer.primaryAddress)
            };
        }

        public static data.models.Customer CustomerViewToCustomerData(web.ViewModels.CustomerModel customer)
        {
            return new data.models.Customer {
                id = customer.id,
                createdOn = customer.createdOn,
                updatedOn = customer.updatedOn,
                firstName = customer.firstName,
                lastName = customer.lastName,
                primaryAddress = AddressViewToAddressData(customer.primaryAddress)
            };
        }

        public static web.ViewModels.CustomerAddressModel AddressDataToAddressView(data.models.CustomerAddress address)
        {
            return new web.ViewModels.CustomerAddressModel {
                id = address.id,
                addressLine1 = address.addressLine1,
                addressLine2 = address.addressLine2,
                city = address.city,
                state = address.state,
                postalCode = address.postalCode,
                country = address.country,
                createdOn  = DateTime.UtcNow,
                updatedOn  = DateTime.UtcNow
            };
        }

        public static data.models.CustomerAddress AddressViewToAddressData(web.ViewModels.CustomerAddressModel address)
        {
            return new data.models.CustomerAddress {
                id = address.id,
                addressLine1 = address.addressLine1,
                addressLine2 = address.addressLine2,
                city = address.city,
                state = address.state,
                postalCode = address.postalCode,
                country = address.country,
                createdOn  = DateTime.UtcNow,
                updatedOn  = DateTime.UtcNow
            };
        }
    }
}