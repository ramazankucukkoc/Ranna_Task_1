﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserOperationClaim:Entity
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public virtual User User { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }
        public UserOperationClaim()
        {

        }
        public UserOperationClaim(int id, int userId, int operationClaimId) : base(id)
        {
            UserId = userId;
            OperationClaimId = operationClaimId;
        }
    }
}
